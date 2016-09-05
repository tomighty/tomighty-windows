//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tomighty.Events;
using Windows.UI.Notifications;

namespace Tomighty.Windows
{
    internal class TomightyApplication : ApplicationContext
    {
        private readonly IPomodoroEngine pomodoroEngine;
        private readonly IContainer components;
        private readonly NotifyIcon notifyIcon;
        private readonly ContextMenuStrip contextMenu;
        private readonly ToolStripMenuItem timeItem;
        private readonly ToolStripMenuItem stopTimerItem;
        private readonly ToolStripMenuItem pomodoroCountItem;
        private readonly ToolStripMenuItem resetCountItem;
        private readonly ToolStripMenuItem startPomodoroItem;
        private readonly ToolStripMenuItem startShortBreakItem;
        private readonly ToolStripMenuItem startLongBreakItem;
        private readonly ToolStripMenuItem exitItem;
        private readonly ToastNotifier toastNotifier = ToastNotificationManager.CreateToastNotifier("Tomighty");

        public TomightyApplication(IPomodoroEngine pomodoroEngine, IEventHub eventHub)
        {
            this.pomodoroEngine = pomodoroEngine;

            eventHub.Subscribe<TimerStarted>(OnTimerStarted);
            eventHub.Subscribe<TimerStopped>(OnTimerStopped);
            eventHub.Subscribe<TimeElapsed>(OnTimeElasped);
            eventHub.Subscribe<PomodoroCountChanged>(OnPomodoroCountChanged);

            components = new Container();

            timeItem = new ToolStripMenuItem("00:00", Images.Clock);
            timeItem.Enabled = false;
            timeItem.Font = new Font(timeItem.Font, FontStyle.Bold);

            stopTimerItem = new ToolStripMenuItem("Stop", Images.Stop, OnStopTimerClick);
            stopTimerItem.Enabled = false;

            pomodoroCountItem = new ToolStripMenuItem();
            pomodoroCountItem.Enabled = false;

            resetCountItem = new ToolStripMenuItem("Reset count");
            resetCountItem.Enabled = false;
            resetCountItem.Click += OnResetPomodoroCountClick;

            startPomodoroItem = new ToolStripMenuItem("Pomodoro", Images.RedTomato, OnStartPomodoroClick);
            startShortBreakItem = new ToolStripMenuItem("Short break", Images.GreenTomato, OnStartShortBreakClick);
            startLongBreakItem = new ToolStripMenuItem("Long break", Images.BlueTomato, OnStartLongBreakClick);

            exitItem = new ToolStripMenuItem("Exit");
            exitItem.Click += new EventHandler(OnExitClick);

            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add(timeItem);
            contextMenu.Items.Add(stopTimerItem);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(pomodoroCountItem);
            contextMenu.Items.Add(resetCountItem);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(startPomodoroItem);
            contextMenu.Items.Add(startShortBreakItem);
            contextMenu.Items.Add(startLongBreakItem);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(new ToolStripMenuItem("About Tomighty", null, (sender, evt) => new AboutForm().ShowDialog()));
            contextMenu.Items.Add(new ToolStripMenuItem("Preferences..."));
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(exitItem);

            notifyIcon = new NotifyIcon(components);
            notifyIcon.Icon = Icons.WhiteTomato;
            notifyIcon.Text = "Tomighty";
            notifyIcon.Visible = true;
            notifyIcon.ContextMenuStrip = contextMenu;

            UpdatePomodoroCount(pomodoroEngine.PomodoroCount);
        }

        private void StartTimer(IntervalType intervalType)
        {
            UpdateContextMenu(() => UpdateTimerStartItems(intervalType));
            Task.Run(() => pomodoroEngine.StartTimer(intervalType));
        }

        private void OnStartPomodoroClick(object sender, EventArgs e) => StartTimer(IntervalType.Pomodoro);
        private void OnStartLongBreakClick(object sender, EventArgs e) => StartTimer(IntervalType.LongBreak);
        private void OnStartShortBreakClick(object sender, EventArgs e) => StartTimer(IntervalType.ShortBreak);
        private void OnStopTimerClick(object sender, EventArgs e) => Task.Run(() => pomodoroEngine.StopTimer());
        private void OnResetPomodoroCountClick(object sender, EventArgs e) => Task.Run(() => pomodoroEngine.ResetPomodoroCount());

        private void OnTimerStarted(TimerStarted timerStarted)
        {
            UpdateContextMenu(() =>
            {
                UpdateRemainingTime(timerStarted.RemainingTime);
                UpdateTimerStartItems(timerStarted.IntervalType);
                notifyIcon.Icon = GetTrayIconFor(timerStarted.IntervalType);
                stopTimerItem.Enabled = true;
            });
        }

        private void OnTimerStopped(TimerStopped timerStopped)
        {
            UpdateContextMenu(() =>
            {
                UpdateRemainingTime(Duration.Zero);
                notifyIcon.Icon = Icons.WhiteTomato;
                stopTimerItem.Enabled = false;
                startPomodoroItem.Enabled = true;
                startShortBreakItem.Enabled = true;
                startLongBreakItem.Enabled = true;
            });
        }

        private void OnTimeElasped(TimeElapsed timeElapsed)
        {
            UpdateContextMenu(() => UpdateRemainingTime(timeElapsed.RemainingTime));
        }
        
        private void OnPomodoroCountChanged(PomodoroCountChanged @event)
        {
            UpdateContextMenu(() =>
            {
                UpdatePomodoroCount(@event.PomodoroCount);
            });
        }

        private void UpdatePomodoroCount(int count)
        {
            pomodoroCountItem.Text = $"Completed pomodoros: {count}";
            resetCountItem.Enabled = count > 0;
        }

        private void UpdateRemainingTime(Duration remainingTime)
        {
            timeItem.Text = remainingTime.ToTimeString();
        }

        private void UpdateTimerStartItems(IntervalType intervalType)
        {
            startPomodoroItem.Enabled = intervalType != IntervalType.Pomodoro;
            startShortBreakItem.Enabled = intervalType != IntervalType.ShortBreak;
            startLongBreakItem.Enabled = intervalType != IntervalType.LongBreak;
        }

        private void OnExitClick(object sender, EventArgs e)
        {
            components.Dispose();
            ExitThread();
        }

        private void UpdateContextMenu(Action action)
        {
            contextMenu.BeginInvoke(action);
        }

        private Icon GetTrayIconFor(IntervalType intervalType)
        {
            if (intervalType == IntervalType.Pomodoro) return Icons.RedTomato;
            if (intervalType == IntervalType.ShortBreak) return Icons.GreenTomato;
            if (intervalType == IntervalType.LongBreak) return Icons.BlueTomato;
            throw new ArgumentException($"Invalid interval type: {intervalType}");
        }
    }
}
