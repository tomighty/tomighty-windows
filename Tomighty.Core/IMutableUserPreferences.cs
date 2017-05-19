//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

namespace Tomighty
{
    public interface IMutableUserPreferences : IUserPreferences
    {
        void SetIntervalDuration(IntervalType intervalType, Duration duration);
        void ShowToastNotificationWhenIntervalIsCompleted(IntervalType intervalType, bool show);
        new int MaxPomodoroCount { get; set; }
    }
}
