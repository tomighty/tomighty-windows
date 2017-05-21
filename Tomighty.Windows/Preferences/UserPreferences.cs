//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Tomighty.Windows.Preferences
{
    public class UserPreferences : IMutableUserPreferences
    {
        private static readonly string FilePath = Path.Combine(Directories.AppData, "preferences.json");
        private static readonly DataContractJsonSerializer Json = new DataContractJsonSerializer(typeof(Values));

        private readonly Values values;

        public UserPreferences()
        {
            values = ReadFromFile() ?? DefaultValues;
        }

        private static Values ReadFromFile()
        {
            if (!File.Exists(FilePath))
                return null;

            using (var file = File.OpenRead(FilePath))
            {
                try
                {
                    return ReplaceInvalidSettingsWithDefaultValues((Values)Json.ReadObject(file));
                }
                catch(SerializationException)
                {
                    return DefaultValues;
                }
            }
        }

        private static Values ReplaceInvalidSettingsWithDefaultValues(Values values)
        {
            if (values.PomodoroDuration <= 0) values.PomodoroDuration = DefaultValues.PomodoroDuration;
            if (values.ShortBreakDuration <= 0) values.ShortBreakDuration = DefaultValues.ShortBreakDuration;
            if (values.LongBreakDuration <= 0) values.LongBreakDuration = DefaultValues.LongBreakDuration;
            if (values.MaxPomodoroCount <= 0) values.MaxPomodoroCount = DefaultValues.MaxPomodoroCount;
            return values;
        }

        private static Values DefaultValues => new Values
        {
            PomodoroDuration = Duration.InMinutes(25).Seconds,
            ShortBreakDuration = Duration.InMinutes(5).Seconds,
            LongBreakDuration = Duration.InMinutes(15).Seconds,
            MaxPomodoroCount = 4,
            ShowToastNotifications = true,
            PlaySoundNotifications = true
        };

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

        public bool ShowToastNotifications
        {
            get { return values.ShowToastNotifications; }
            set { values.ShowToastNotifications = value; }
        }

        public bool PlaySoundNotifications
        {
            get { return values.PlaySoundNotifications; }
            set { values.PlaySoundNotifications = value; }
        }

        public void Update(Action<IMutableUserPreferences> action)
        {
            action(this);
            using (var file = new FileStream(FilePath, FileMode.Create))
            {
                Json.WriteObject(file, values);
            }
        }

        [DataContract]
        private class Values
        {
            [DataMember] public int PomodoroDuration { get; set; }
            [DataMember] public int ShortBreakDuration { get; set; }
            [DataMember] public int LongBreakDuration { get; set; }
            [DataMember] public int MaxPomodoroCount { get; set; }
            [DataMember] public bool ShowToastNotifications { get; set; }
            [DataMember] public bool PlaySoundNotifications { get; set; }
        }
    }
}
