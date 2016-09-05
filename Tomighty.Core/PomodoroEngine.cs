//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System;
using Tomighty.Events;

namespace Tomighty
{
    public class PomodoroEngine : IPomodoroEngine
    {
        private readonly ITimer timer;
        private readonly IUserPreferences userPreferences;
        private readonly IEventHub eventHub;

        public PomodoroEngine(ITimer timer, IUserPreferences userPreferences, IEventHub eventHub)
        {
            this.timer = timer;
            this.userPreferences = userPreferences;
            this.eventHub = eventHub;

            eventHub.Subscribe<TimerStopped>(OnTimerStopped);
        }

        public int PomodoroCount { get; private set; }

        public IntervalType SuggestedBreakType => PomodoroCount != userPreferences.MaxPomodoroCount ? IntervalType.ShortBreak : IntervalType.LongBreak;

        public void StartTimer(IntervalType intervalType)
        {
            var duration = userPreferences.GetIntervalDuration(intervalType);
            timer.Start(duration, intervalType);
        }

        public void StopTimer()
        {
            timer.Stop();
        }

        private void OnTimerStopped(TimerStopped timerStopped)
        {
            if (timerStopped.IntervalType == IntervalType.Pomodoro && timerStopped.RemainingTime.Seconds == 0)
            {
                PomodoroCompleted(timerStopped.Duration);
            }
        }

        private void PomodoroCompleted(Duration duration)
        {
            IncreasePomodoroCount();
            eventHub.Publish(new PomodoroCompleted(duration));
        }

        private void IncreasePomodoroCount()
        {
            if (++PomodoroCount > userPreferences.MaxPomodoroCount)
            {
                PomodoroCount = 1;
            }
        }
    }
}
