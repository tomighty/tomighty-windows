using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Threading;
using Tomighty.Windows;

namespace Tomighty.Update.Swap
{
    static class Program
    {
        private static readonly Logger logger = new Logger("swap");

        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();

            if (args.Length != 5)
            {
                logger.Error($"Wrong number of arguments: {args.Length}, exiting now");
                return;
            }

            var processId = args[1];
            var exePath = args[2];
            var sourcePackage = args[3];
            var restart = args[4];

            if (!IsInteger(processId))
            {
                logger.Error($"Invalid process id: {processId}");
                return;
            }

            if (!File.Exists(exePath))
            {
                logger.Error($"File not found: {exePath}");
                return;
            }

            if (!File.Exists(sourcePackage))
            {
                logger.Error($"File not found: {sourcePackage}");
                return;
            }

            var targetDir = Path.GetDirectoryName(exePath);

            try
            {
                Swap(int.Parse(processId), exePath, sourcePackage, targetDir, restart == "true");
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
        }

        private static void Swap(int processId, string exePath, string sourcePackage, string targetDir, bool restart)
        {
            try
            {
                logger.Info($"Waiting for process {processId} to exit");
                Process.GetProcessById(processId).WaitForExit();

                logger.Info($"Process {processId} has exited");
            }
            catch (ArgumentException)
            {
                logger.Info($"Process {processId} doesn't exist, probably exited");
            }

            Thread.Sleep(500);

            logger.Info($"Deleting directory contents: {targetDir}");
            DeleteDirectoryContents(targetDir);

            logger.Info($"Extracting files from `{sourcePackage}` into `{targetDir}`");
            ZipFile.ExtractToDirectory(sourcePackage, targetDir);

            if (restart)
            {
                logger.Info($"Starting process {exePath}");
                Process.Start(exePath);
            }

            logger.Info($"Done");
        }

        private static void DeleteDirectoryContents(string targetDir)
        {
            foreach (var file in Directory.GetFiles(targetDir))
            {
                File.Delete(file);
            }

            foreach (var dir in Directory.GetDirectories(targetDir))
            {
                new DirectoryInfo(dir).Delete(true);
            }
        }

        private static bool IsInteger(string s)
        {
            return s != null && Regex.IsMatch(s, @"^\d+$");
        }
    }
}
