//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

namespace Tomighty.Events
{
    public class TimeElapsed
    {
        public TimeElapsed(IntervalType intervalType, Duration duration, Duration remainingTime)
        {
            IntervalType = intervalType;
            Duration = duration;
            RemainingTime = remainingTime;
        }

        public Duration Duration { get; }
        public IntervalType IntervalType { get; }
        public Duration RemainingTime { get; }
    }
}
