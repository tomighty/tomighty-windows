//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System;
using System.Collections.Generic;
using System.IO;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace Tomighty.Windows.Notifications
{
    internal static class Toasts
    {
        private static readonly string RedTomatoImage = new Uri(Path.GetFullPath(@"Resources\Toasts\image_toast_tomato_red.png")).AbsoluteUri;
        private static readonly string GreenTomatoImage = new Uri(Path.GetFullPath(@"Resources\Toasts\image_toast_tomato_green.png")).AbsoluteUri;
        private static readonly string BlueTomatoImage = new Uri(Path.GetFullPath(@"Resources\Toasts\image_toast_tomato_blue.png")).AbsoluteUri;
        private static readonly XmlDocument PomodoroCompletedTakeShortBreakTemplate = FillIntervalCompletedTemplate("Pomodoro", RedTomatoImage, TimerAction.StartShortBreak);
        private static readonly XmlDocument PomodoroCompletedTakeLongBreakTemplate = FillIntervalCompletedTemplate("Pomodoro", RedTomatoImage, TimerAction.StartLongBreak);
        private static readonly XmlDocument ShortBreakCompletedTemplate = FillIntervalCompletedTemplate("Short break", GreenTomatoImage, TimerAction.StartPomodoro);
        private static readonly XmlDocument LongBreakCompletedTemplate = FillIntervalCompletedTemplate("Long break", BlueTomatoImage, TimerAction.StartPomodoro);
        private static readonly XmlDocument FirstRunTemplate = ToXmlDocument(Properties.Resources.toast_template_first_run.Replace("{image_src}", RedTomatoImage));

        public static ToastNotification FirstRun()
        {
            return new ToastNotification(FirstRunTemplate);
        }

        public static ToastNotification IntervalCompleted(IntervalType completedIntervalType, IntervalType suggestedBreakType)
        {
            if (completedIntervalType == IntervalType.Pomodoro && suggestedBreakType == IntervalType.ShortBreak)
                return new ToastNotification(PomodoroCompletedTakeShortBreakTemplate);

            if (completedIntervalType == IntervalType.Pomodoro && suggestedBreakType == IntervalType.LongBreak)
                return new ToastNotification(PomodoroCompletedTakeLongBreakTemplate);

            if (completedIntervalType == IntervalType.ShortBreak)
                return new ToastNotification(ShortBreakCompletedTemplate);

            if (completedIntervalType == IntervalType.LongBreak)
                return new ToastNotification(LongBreakCompletedTemplate);

            throw new ArgumentException($"Invalid arguments: {nameof(completedIntervalType)}={completedIntervalType} {nameof(suggestedBreakType)}={suggestedBreakType}");
        }

        private static XmlDocument FillIntervalCompletedTemplate(string intervalType, string imageSrc, TimerAction action)
        {
            return ToXmlDocument(Properties.Resources.toast_template_interval_completed
                .Replace("{interval_type}", intervalType)
                .Replace("{image_src}", imageSrc)
                .Replace("{action_content}", action.Content)
                .Replace("{action_args}", action.Args));
        }

        private static XmlDocument ToXmlDocument(string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            return doc;
        }

        public class TimerAction
        {
            public static readonly TimerAction StartPomodoro = new TimerAction("start_pomodoro", "Start pomodoro", IntervalType.Pomodoro);
            public static readonly TimerAction StartShortBreak = new TimerAction("start_short_break", "Take a short break", IntervalType.ShortBreak);
            public static readonly TimerAction StartLongBreak = new TimerAction("start_long_break", "Take a long break", IntervalType.LongBreak);

            public static readonly IDictionary<string, TimerAction> WithArgs = new Dictionary<string, TimerAction>
            {
                { StartPomodoro.Args, StartPomodoro },
                { StartShortBreak.Args, StartShortBreak },
                { StartLongBreak.Args, StartLongBreak }
            };

            private TimerAction(string args, string content, IntervalType intervalType)
            {
                Args = args;
                Content = content;
                IntervalType = intervalType;
            }

            public string Args { get; }
            public string Content { get; }
            public IntervalType IntervalType { get; }
        }
    }
}
