//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System.ComponentModel;
using System.Windows.Forms;
using Tomighty.Windows.About;
using Tomighty.Windows.Notifications;
using Tomighty.Windows.Preferences;
using Tomighty.Windows.Timer;
using Tomighty.Windows.Tray;

namespace Tomighty.Windows
{
    internal class TomightyApplication : ApplicationContext
    {
        public TomightyApplication()
        {
            var eventHub = new SynchronousEventHub();
            var timer = new Tomighty.Timer(eventHub);
            var userPreferences = new UserPreferences();
            var pomodoroEngine = new PomodoroEngine(timer, userPreferences, eventHub);

            var trayMenu = new TrayMenu() as ITrayMenu;
            var trayIcon = CreateTrayIcon(trayMenu);
            var timerWindowPresenter = new TimerWindowPresenter(pomodoroEngine, timer, eventHub);

            new TrayIconController(trayIcon, timerWindowPresenter, eventHub);
            new TrayMenuController(trayMenu, this, pomodoroEngine, eventHub);
            new NotificationsPresenter(pomodoroEngine, userPreferences, eventHub);
            new SoundNotificationPlayer(userPreferences, eventHub);
            new AutoUpdate(userPreferences).Start();

            var aboutWindowPresenter = new AboutWindowPresenter();
            var userPreferencesPresenter = new UserPreferencesPresenter(userPreferences);

            trayMenu.OnAboutClick((sender, e) => aboutWindowPresenter.Show());
            trayMenu.OnPreferencesClick((sender, e) => userPreferencesPresenter.Show());

            ThreadExit += (sender, e) => trayIcon.Dispose();
        }
        
        private static NotifyIcon CreateTrayIcon(ITrayMenu trayMenu)
        {
            var trayIcon = new NotifyIcon(new Container());

            trayIcon.Text = "Tomighty";
            trayIcon.Icon = Properties.Resources.icon_tomato_white;
            trayIcon.ContextMenuStrip = trayMenu.Component;
            trayIcon.Visible = true;

            return trayIcon;
        }
    }
}
