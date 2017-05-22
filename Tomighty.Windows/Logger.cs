using System;
using System.IO;

namespace Tomighty.Windows
{
    class Logger : IDisposable
    {
        private const long MaxFileSize = 1024 * 512; //512KB

        private readonly StreamWriter writer;

        public Logger(string name)
        {
            writer = new StreamWriter(GetFile(name + ".log"));
        }

        private FileStream GetFile(string name)
        {
            var path = Path.Combine(Directories.AppData, name);

            if (HasReachedSizeLimit(path))
            {
                try
                {
                   File.Delete(path);
                }
                catch
                {
                    //That's ok, let's not break the program just because
                    //we can't delete the log file
                }
            }
            return new FileStream(path, FileMode.Append);
        }

        private bool HasReachedSizeLimit(string filepath)
        {
            return File.Exists(filepath) 
                && new FileInfo(filepath).Length > MaxFileSize;
        }

        private void Log(string level, string msg)
        {
            writer.WriteLine($"{DateTimeOffset.Now.ToString()} [{level}] {msg}");
            writer.Flush();
        }

        public void Info(string msg)
        {
            Log("INFO", msg);
        }

        public void Error(string msg)
        {
            Log("ERROR", msg);
        }

        public void Error(Exception e)
        {
            Error(e.ToString());
        }

        public void Dispose()
        {
            if (writer != null)
                writer.Close();
        }
    }
}
