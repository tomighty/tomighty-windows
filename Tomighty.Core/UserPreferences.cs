using System;
using System.Configuration;

namespace Tomighty
{
    public class UserPreferences : ApplicationSettingsBase, IMutableUserPreferences
    {
        public Duration GetIntervalDuration(IntervalType intervalType)
        {
            if (intervalType == IntervalType.Pomodoro) return new Duration(PomodoroDuration);
            if (intervalType == IntervalType.ShortBreak) return new Duration(ShortBreakDuration);
            if (intervalType == IntervalType.LongBreak) return new Duration(LongBreakDuration);
            throw new ArgumentException($"Unsupported interval type: {intervalType}");
        }

        public void SetIntervalDuration(IntervalType intervalType, Duration duration)
        {
            if (intervalType == IntervalType.Pomodoro) PomodoroDuration = duration.Seconds;
            else if (intervalType == IntervalType.ShortBreak) ShortBreakDuration = duration.Seconds;
            else if (intervalType == IntervalType.LongBreak) LongBreakDuration = duration.Seconds;
            else throw new ArgumentException($"Unsupported interval type: {intervalType}");
        }

        [UserScopedSetting]
        [DefaultSettingValue("25")]
        public int PomodoroDuration
        {
            get { return (int)this["PomodoroDuration"]; }
            set { this["PomodoroDuration"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("5")]
        public int ShortBreakDuration
        {
            get { return (int)this["ShortBreakDuration"]; }
            set { this["ShortBreakDuration"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("15")]
        public int LongBreakDuration
        {
            get { return (int)this["LongBreakDuration"]; }
            set { this["LongBreakDuration"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("4")]
        public int MaxPomodoroCount
        {
            get { return (int)this["MaxPomodoroCount"]; }
            set { this["MaxPomodoroCount"] = value; }
        }

        public void Update(Action<IMutableUserPreferences> action)
        {
            action(this);
            Save();
        }
    }
}
