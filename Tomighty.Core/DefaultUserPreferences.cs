//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System;

namespace Tomighty
{
    public class DefaultUserPreferences : IUserPreferences
    {
        public Duration GetIntervalDuration(IntervalType intervalType)
        {
            if (intervalType == IntervalType.Pomodoro) return Duration.InMinutes(25);
            if (intervalType == IntervalType.LongBreak) return Duration.InMinutes(15);
            if (intervalType == IntervalType.ShortBreak) return Duration.InMinutes(5);

            throw new ArgumentException($"Unsupported interval type: {intervalType}");
        }

        public int MaxPomodoroCount => 4;
    }
}