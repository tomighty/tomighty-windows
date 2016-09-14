//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

namespace Tomighty.Windows.Tray
{
    internal interface ITrayMenuMutator
    {
        void UpdateRemainingTime(string text);
        void EnableStartPomodoroItem(bool enable);
        void EnableStartShortBreakItem(bool enable);
        void EnableStartLongBreakItem(bool enable);
        void EnableStopTimerItem(bool enable);
        void EnableResetPomodoroCountItem(bool enable);
        void UpdatePomodoroCount(int count);
    }
}
