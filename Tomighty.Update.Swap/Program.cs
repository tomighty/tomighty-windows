using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Threading;

namespace Tomighty.Update.Swap
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();

            if (args.Length != 4)
            {
                Logger.Error($"Wrong number of arguments: {args.Length}, exiting now");
                return;
            }

            var processId = args[1];
            var exePath = args[2];
            var sourcePackage = args[3];

            if (!IsInteger(processId))
            {
                Logger.Error($"Invalid process id: {processId}");
                return;
            }

            if (!File.Exists(exePath))
            {
                Logger.Error($"File not found: {exePath}");
                return;
            }

            if (!File.Exists(sourcePackage))
            {
                Logger.Error($"File not found: {sourcePackage}");
                return;
            }

            var targetDir = Path.GetDirectoryName(exePath);

            try
            {
                Swap(int.Parse(processId), exePath, sourcePackage, targetDir);
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
        }

        private static void Swap(int processId, string exePath, string sourcePackage, string targetDir)
        {
            try
            {
                Logger.Info($"Waiting for process {processId} to exit");
                Process.GetProcessById(processId).WaitForExit();

                Logger.Info($"Process {processId} has exited");
            }
            catch (ArgumentException)
            {
                Logger.Info($"Process {processId} doesn't exist, probably exited");
            }

            Thread.Sleep(500);

            Logger.Info($"Deleting directory: {targetDir}");
            new DirectoryInfo(targetDir).Delete(true);

            Logger.Info($"Extracting files from `{sourcePackage}` into `{targetDir}`");
            ZipFile.ExtractToDirectory(sourcePackage, targetDir);

            Logger.Info($"Starting process {exePath}");
            Process.Start(exePath);

            Logger.Info($"Done");
        }

        private static bool IsInteger(string s)
        {
            return s != null && Regex.IsMatch(s, @"^\d+$");
        }
    }
}
