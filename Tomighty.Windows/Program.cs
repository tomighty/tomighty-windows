//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System;
using System.Windows.Forms;

namespace Tomighty.Windows
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IEventHub eventHub = new SynchronousEventHub();
            ITimer timer = new Timer(eventHub);
            IUserPreferences userPreferences = new UserPreferences();
            IPomodoroEngine pomodoroEngine = new PomodoroEngine(timer, userPreferences, eventHub);

            new ToastController(pomodoroEngine, eventHub);

            Application.Run(new TomightyApplication(pomodoroEngine, timer, userPreferences, eventHub));
        }
    }
}
