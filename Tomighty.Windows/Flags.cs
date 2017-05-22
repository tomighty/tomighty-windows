using System;
using System.IO;

namespace Tomighty.Windows
{
    public class Flags
    {
        private readonly string dir;

        public Flags(string name)
        {
            dir = Path.Combine(Directories.AppData, name);
        }

        public bool IsOn(string name, bool defaultValue)
        {
            return ReadFile(name, defaultValue);
        }

        public void TurnOn(string name)
        {
            WriteFile(name, true);
        }

        public void TurnOff(string name)
        {
            WriteFile(name, false);
        }

        private string GetFile(string name) => Path.Combine(dir, name);

        private void EnsureDirectoryExists()
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }

        private void WriteFile(string name, bool value)
        {
            EnsureDirectoryExists();
            File.WriteAllText(GetFile(name), value ? "1" : "0");
        }

        private bool ReadFile(string name, bool defaultValue)
        {
            EnsureDirectoryExists();

            var file = GetFile(name);

            if (File.Exists(file))
                return File.ReadAllText(file) == "1" ? true : false;

            return defaultValue;
        }
    }
}
