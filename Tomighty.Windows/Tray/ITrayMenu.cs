//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System;
using System.Windows.Forms;

namespace Tomighty.Windows.Tray
{
    internal interface ITrayMenu
    {
        ContextMenuStrip Component { get; }

        void OnAboutClick(EventHandler handler);
        void OnPreferencesClick(EventHandler handler);
        void OnStartPomodoroClick(EventHandler handler);
        void OnStartLongBreakClick(EventHandler handler);
        void OnStartShortBreakClick(EventHandler handler);
        void OnStopTimerClick(EventHandler handler);
        void OnResetPomodoroCountClick(EventHandler handler);
        void OnExitClick(EventHandler handler);
        void Update(Action<ITrayMenuMutator> action);
    }
}
