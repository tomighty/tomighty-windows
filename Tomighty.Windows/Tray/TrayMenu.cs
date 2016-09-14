//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tomighty.Windows.Tray
{
    internal class TrayMenu : ITrayMenu, ITrayMenuMutator
    {
        private readonly ContextMenuStrip contextMenu;
        private readonly ToolStripMenuItem remainingTimeItem;
        private readonly ToolStripMenuItem stopTimerItem;
        private readonly ToolStripMenuItem pomodoroCountItem;
        private readonly ToolStripMenuItem resetPomodoroCountItem;
        private readonly ToolStripMenuItem startPomodoroItem;
        private readonly ToolStripMenuItem startShortBreakItem;
        private readonly ToolStripMenuItem startLongBreakItem;
        private readonly ToolStripMenuItem aboutItem;
        private readonly ToolStripMenuItem exitItem;
        private readonly ToolStripMenuItem preferencesItem;

        public TrayMenu()
        {
            remainingTimeItem = new ToolStripMenuItem("00:00", Properties.Resources.image_clock);
            remainingTimeItem.Enabled = false;
            remainingTimeItem.Font = new Font(remainingTimeItem.Font, FontStyle.Bold);

            stopTimerItem = new ToolStripMenuItem("Stop", Properties.Resources.image_stop);

            pomodoroCountItem = new ToolStripMenuItem();
            pomodoroCountItem.Enabled = false;

            resetPomodoroCountItem = new ToolStripMenuItem("Reset count");
            resetPomodoroCountItem.Enabled = false;

            startPomodoroItem = new ToolStripMenuItem("Pomodoro", Properties.Resources.image_tomato_red);
            startShortBreakItem = new ToolStripMenuItem("Short break", Properties.Resources.image_tomato_green);
            startLongBreakItem = new ToolStripMenuItem("Long break", Properties.Resources.image_tomato_blue);

            aboutItem = new ToolStripMenuItem("About Tomighty");
            preferencesItem = new ToolStripMenuItem("Preferences...");
            exitItem = new ToolStripMenuItem("Exit");

            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add(remainingTimeItem);
            contextMenu.Items.Add(stopTimerItem);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(pomodoroCountItem);
            contextMenu.Items.Add(resetPomodoroCountItem);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(startPomodoroItem);
            contextMenu.Items.Add(startShortBreakItem);
            contextMenu.Items.Add(startLongBreakItem);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(aboutItem);
            contextMenu.Items.Add(preferencesItem);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(exitItem);
        }

        public ContextMenuStrip Component => contextMenu;

        public void OnStartPomodoroClick(EventHandler handler) => startPomodoroItem.Click += handler;
        public void OnStartLongBreakClick(EventHandler handler) => startLongBreakItem.Click += handler;
        public void OnStartShortBreakClick(EventHandler handler) => startShortBreakItem.Click += handler;
        public void OnStopTimerClick(EventHandler handler) => stopTimerItem.Click += handler;
        public void OnResetPomodoroCountClick(EventHandler handler) => resetPomodoroCountItem.Click += handler;
        public void OnAboutClick(EventHandler handler) => aboutItem.Click += handler;
        public void OnPreferencesClick(EventHandler handler) => preferencesItem.Click += handler;
        public void OnExitClick(EventHandler handler) => exitItem.Click += handler;

        public void UpdateRemainingTime(string text) => remainingTimeItem.Text = text;
        public void UpdatePomodoroCount(int count) => pomodoroCountItem.Text = $"Completed pomodoros: {count}";
        public void EnableStartPomodoroItem(bool enable) => startPomodoroItem.Enabled = enable;
        public void EnableStartShortBreakItem(bool enable) => startShortBreakItem.Enabled = enable;
        public void EnableStartLongBreakItem(bool enable) => startLongBreakItem.Enabled = enable;
        public void EnableStopTimerItem(bool enable) => stopTimerItem.Enabled = enable;
        public void EnableResetPomodoroCountItem(bool enable) => resetPomodoroCountItem.Enabled = enable;

        public void Update(Action<ITrayMenuMutator> action)
        {
            if (contextMenu.IsHandleCreated)
            {
                contextMenu.BeginInvoke(action, this);
            }
            else
            {
                action(this);
            }
        }
    }
}
