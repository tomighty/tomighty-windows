//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

namespace Tomighty
{
    public interface ITimer : ICountdownClock
    {
        void Start(Duration duration, IntervalType intervalType);
        void Stop();
    }
}