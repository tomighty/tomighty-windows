//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System;
using Tomighty.Windows.Properties;

namespace Tomighty.Windows
{
    internal static class IntervalTypeExtensions
    {
        public static string GetName(this IntervalType intervalType)
        {
            switch (intervalType)
            {
                case IntervalType.Pomodoro: return Resources.String_Pomodoro;
                case IntervalType.ShortBreak: return Resources.String_ShortBreak;
                case IntervalType.LongBreak: return Resources.String_LongBreak;
                default: throw new ArgumentException($"Unknown interval type: {intervalType}");
            }
        }
    }
}
