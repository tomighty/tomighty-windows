//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tomighty.Windows.Preferences;
using Tomighty.Windows.Util;

namespace Tomighty.Windows
{
    internal class AutoUpdate
    {
        private const int CheckIntervalInHours = 24;

        private static readonly Logger logger = new Logger("update");

        private readonly UserPreferences userPreferences;

        public AutoUpdate(UserPreferences userPreferences)
        {
            this.userPreferences = userPreferences;
            Application.ApplicationExit += Update;
        }

        private static string LatestPackageFile => Path.Combine(Directories.AppData, "latest.zip");

        private static string LastDownloadedVersionFile => Path.Combine(Directories.AppData, "latest.version");

        private static string SwapProgramFile => Path.Combine(Directories.ProgramLocation, "Tomighty.Update.Swap.exe");

        public void Start()
        {
            if (userPreferences.AutoUpdate)
            {
                Task.Run(async () =>
                {
                    try
                    {
                        await CheckIfNecessary();
                    }
                    catch(Exception e)
                    {
                        logger.Error(e);
                    }
                });
            }
        }

        private async Task CheckIfNecessary()
        {
            if (IsTimeToCheck)
            {
                await Check();
            }
        }

        public bool IsTimeToCheck => 
            !File.Exists(LastDownloadedVersionFile) ||
            (DateTime.Now - LastCheckTime).TotalHours > CheckIntervalInHours;

        private static DateTime LastCheckTime => File.GetLastWriteTime(LastDownloadedVersionFile);

        private static void ResetLastCheckTime()
        {
            if (File.Exists(LastDownloadedVersionFile))
            {
                File.SetLastWriteTime(LastDownloadedVersionFile, DateTime.Now);
            }
        }

        private async Task Check()
        {
            logger.Info("Checking");

            var client = new HttpClient();
            var result = await client.GetAsync(URLs.UpdateFeed);

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                logger.Error($"Received {result.StatusCode} from {URLs.UpdateFeed}");
                return;
            }

            var content = await result.Content.ReadAsStringAsync();
            var lines = content.Split('\t');

            if (lines.Length != 3)
            {
                logger.Error($"Invalid feed file");
                return;
            }

            var latestVersion = lines[0];

            if (latestVersion == GetLastDownloadedVersion())
            {
                logger.Info($"Latest version has already been downloaded: {latestVersion}");
                ResetLastCheckTime();
                return;
            }

            if (Version.Product == latestVersion)
            {
                logger.Info($"Already running the latest version: {latestVersion}");
                ResetLastCheckTime();
                return;
            }

            var url = lines[1];
            var sha256 = lines[2];

            if (await Download(url, sha256))
            {
                File.WriteAllText(LastDownloadedVersionFile, latestVersion);
            }
        }

        private async Task<bool> Download(string url, string expectedSha256)
        {
            logger.Info($"Downloading {url}");

            var client = new HttpClient();
            var result = await client.GetAsync(url);

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                logger.Error($"Received {result.StatusCode} from {url}");
                return false;
            }

            var tempFile = LatestPackageFile + ".tmp";

            using (var input = await result.Content.ReadAsStreamAsync())
            {
                using (var output = new FileStream(tempFile, FileMode.Create))
                {
                    await input.CopyToAsync(output);
                }
            }

            logger.Info($"Download completed");

            using (var stream = new FileStream(tempFile, FileMode.Open))
            {
                var sha256 = Hash.Sha256(stream);
                if (sha256 != expectedSha256)
                {
                    logger.Error($"Integrity error: expected hash {expectedSha256} instead of {sha256}");
                    return false;
                }
            }

            if (File.Exists(LatestPackageFile))
            {
                File.Delete(LatestPackageFile);
            }

            File.Move(tempFile, LatestPackageFile);

            logger.Info($"New version available at {LatestPackageFile}");

            return true;
        }

        private void Update(object sender, EventArgs e)
        {
            try
            {
                if (ShouldUpdate)
                {
                    logger.Info($"Updating from version {Version.Product} to {GetLastDownloadedVersion()}");

                    var processId = Process.GetCurrentProcess().Id;
                    var tomighty = Assembly.GetEntryAssembly().Location;
                    var restart = false;
                    var tempSwapProgramFile = CopySwapProgramFileToTempDir();
                    Process.Start(tempSwapProgramFile, $"{processId} \"{tomighty}\" \"{LatestPackageFile}\" {restart}");
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
        }

        private static string CopySwapProgramFileToTempDir()
        {
            var file = Path.Combine(Path.GetTempPath(), Path.GetFileName(SwapProgramFile));
            File.Copy(SwapProgramFile, file, true);
            return file;
        }

        public bool ShouldUpdate =>
            userPreferences.AutoUpdate &&
            IsOutdated &&
            File.Exists(LatestPackageFile);

        private static bool IsOutdated
        {
            get
            {
                string latest = GetLastDownloadedVersion();
                return !string.IsNullOrEmpty(latest) && Version.Product != latest;
            }
        }

        private static string GetLastDownloadedVersion()
        {
            var file = LastDownloadedVersionFile;
            return File.Exists(file) ? File.ReadAllText(file) : null;
        }
    }
}
