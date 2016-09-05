//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

namespace Tomighty
{
    public interface IPomodoroEngine
    {
        void StartTimer(IntervalType intervalType);
        void StopTimer();
        void ResetPomodoroCount();

        int PomodoroCount { get; }
        IntervalType SuggestedBreakType { get; }
    }
}
