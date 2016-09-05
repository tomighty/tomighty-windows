//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System;

namespace Tomighty
{
    public struct Duration
    {
        public static readonly Duration Zero = new Duration();

        public static Duration InSeconds(int seconds) => new Duration(seconds);
        public static Duration InMinutes(int minutes) => new Duration(minutes * 60);

        public Duration(int seconds)
        {
            if(seconds < 0)
                throw new ArgumentException($"Invalid duration of {seconds} seconds");

            Seconds = seconds;
        }

        public int Seconds { get; }

        public Duration AddSeconds(int delta) => new Duration(Seconds + delta);

        public override string ToString() => $"{GetType().Name}({Seconds})";

        public string ToTimeString()
        {
            int minutes = Seconds / 60;
            int seconds = Seconds - minutes * 60;
            return $"{minutes.ToString("0#")}:{seconds.ToString("0#")}";
        }

        public static bool operator ==(Duration a, Duration b) => a.Seconds == b.Seconds;
        public static bool operator !=(Duration a, Duration b) => a.Seconds != b.Seconds;
    }
}