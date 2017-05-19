//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System;

namespace Tomighty
{
    public interface IUserPreferences
    {
        Duration GetIntervalDuration(IntervalType intervalType);
        int MaxPomodoroCount { get; }
        bool ShowToastNotifications { get; }

        void Update(Action<IMutableUserPreferences> action);
    }
}