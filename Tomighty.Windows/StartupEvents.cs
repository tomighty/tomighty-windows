using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomighty.Windows.Events;

namespace Tomighty.Windows
{
    class StartupEvents
    {
        public StartupEvents(IEventHub eventHub)
        {
            Task.Run(() =>
            {
                if (ReadAndFlip("firstrun", true))
                    eventHub.Publish(new FirstRun());
            });
        }

        private bool ReadAndFlip(string name, bool defaultValue)
        {
            var dir = Path.Combine(Directories.AppData, "startup");

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var file = Path.Combine(dir, name);
            bool value = ReadFile(file, defaultValue);

            WriteFile(file, !value);

            return value;
        }

        private static void WriteFile(string file, bool value)
        {
            File.WriteAllText(file, value ? "1" : "0");
        }

        private static bool ReadFile(string file, bool defaultValue)
        {
            if (File.Exists(file))
                return File.ReadAllText(file) == "1" ? true : false;

            return defaultValue;
        }
    }
}
