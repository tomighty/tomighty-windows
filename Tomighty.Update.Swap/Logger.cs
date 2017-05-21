using System;
using System.IO;
using Tomighty.Windows;

namespace Tomighty.Update.Swap
{
    class Logger
    {
        private const long MaxFileSize = 1048576; //1MB

        private static StreamWriter writer = new StreamWriter(GetFile());

        private static FileStream GetFile()
        {
            var path = Path.Combine(Directories.AppData, "update.log");

            if (HasReachedSizeLimit(path))
            {
                try
                {
                   File.Delete(path);
                }
                catch
                {
                    //That's ok, let's not disrupt the update process just because
                    //we can't delete the log file
                }
            }
            return new FileStream(path, FileMode.Append);
        }

        private static bool HasReachedSizeLimit(string filepath)
        {
            return File.Exists(filepath) 
                && new FileInfo(filepath).Length > MaxFileSize;
        }

        private static void Log(string level, string msg)
        {
            writer.WriteLine($"{DateTimeOffset.Now.ToString()} [{level}] {msg}");
            writer.Flush();
        }

        public static void Info(string msg)
        {
            Log("INFO", msg);
        }

        public static void Error(string msg)
        {
            Log("ERROR", msg);
        }

        public static void Error(Exception e)
        {
            Error(e.ToString());
        }
    }
}
