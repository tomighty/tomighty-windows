//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System.Timers;
using Tomighty.Events;
using SystemTimer = System.Timers.Timer;

namespace Tomighty
{
    public class Timer : ITimer
    {
        private const int IntervalInSeconds = 1;

        private readonly SystemTimer systemTimer = new SystemTimer();
        private readonly IEventHub eventHub;

        // Mutable fields
        private Duration remainingTime = Duration.Zero;
        private IntervalType intervalType;
        private Duration duration;

        public Timer(IEventHub eventHub)
        {
            this.eventHub = eventHub;

            systemTimer.Interval = IntervalInSeconds * 1000;
            systemTimer.AutoReset = true;
            systemTimer.Elapsed += SystemTimerOnElapsed;
        }

        public void Start(Duration duration, IntervalType intervalType)
        {
            this.duration = duration;
            this.intervalType = intervalType;

            remainingTime = duration;

            systemTimer.Start();

            eventHub.Publish(new TimerStarted(intervalType, duration, remainingTime));
        }

        public void Stop()
        {
            systemTimer.Stop();

            eventHub.Publish(new TimerStopped(intervalType, duration, remainingTime));

            remainingTime = Duration.Zero;
        }

        private void DecreaseRemainingTime(int seconds)
        {
            remainingTime = remainingTime.AddSeconds(-seconds);

            eventHub.Publish(new TimeElapsed(intervalType, duration, remainingTime));

            if (remainingTime.Seconds == 0)
            {
                Stop();
            }
        }

        private void SystemTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            DecreaseRemainingTime(IntervalInSeconds);
        }
    }
}