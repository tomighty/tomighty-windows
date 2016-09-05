//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

namespace Tomighty.Events
{
    public class PomodoroCompleted
    {
        public PomodoroCompleted(Duration duration)
        {
            Duration = duration;
        }

        public Duration Duration { get; }
    }
}