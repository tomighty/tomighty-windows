//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using Newtonsoft.Json;
using System;
using System.IO;

namespace Tomighty.Windows
{
    public class UserPreferences : IMutableUserPreferences
    {
        private static readonly string FilePath = Path.Combine(GetOrCreateApplicationDirectory(), "preferences.json");

        private readonly Values values;

        public UserPreferences()
        {
            values = ReadFromFile() ?? GetDefaultValues();
        }

        private static Values ReadFromFile()
        {
            if (!File.Exists(FilePath))
                return null;

            var json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<Values>(json);
        }

        private static Values GetDefaultValues()
        {
            return new Values
            {
                PomodoroDuration = Duration.InMinutes(25).Seconds,
                ShortBreakDuration = Duration.InMinutes(5).Seconds,
                LongBreakDuration = Duration.InMinutes(15).Seconds,
                MaxPomodoroCount = 4
            };
        }

        private static string GetOrCreateApplicationDirectory()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Tomighty");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }

        public Duration GetIntervalDuration(IntervalType intervalType)
        {

            if (intervalType == IntervalType.Pomodoro) return new Duration(values.PomodoroDuration);
            if (intervalType == IntervalType.ShortBreak) return new Duration(values.ShortBreakDuration);
            if (intervalType == IntervalType.LongBreak) return new Duration(values.LongBreakDuration);
            throw new ArgumentException($"Unsupported interval type: {intervalType}");
        }

        public void SetIntervalDuration(IntervalType intervalType, Duration duration)
        {
            if (intervalType == IntervalType.Pomodoro) values.PomodoroDuration = duration.Seconds;
            else if (intervalType == IntervalType.ShortBreak) values.ShortBreakDuration = duration.Seconds;
            else if (intervalType == IntervalType.LongBreak) values.LongBreakDuration = duration.Seconds;
            else throw new ArgumentException($"Unsupported interval type: {intervalType}");
        }

        public int MaxPomodoroCount
        {
            get { return values.MaxPomodoroCount; }
            set { values.MaxPomodoroCount = value; }
        }

        public void Update(Action<IMutableUserPreferences> action)
        {
            action(this);
            var json = JsonConvert.SerializeObject(values, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }

        private class Values
        {
            public int PomodoroDuration { get; set; }
            public int ShortBreakDuration { get; set; }
            public int LongBreakDuration { get; set; }
            public int MaxPomodoroCount { get; set; }
        }
    }
}
