using System.Windows.Forms;

namespace Tomighty.Windows
{
    public partial class UserPreferencesForm : Form
    {
        private IUserPreferences userPreferences;

        public UserPreferencesForm(IUserPreferences userPreferences)
        {
            this.userPreferences = userPreferences;

            InitializeComponent();

            pomodoroDurationTextBox.Value = userPreferences.GetIntervalDuration(IntervalType.Pomodoro).Minutes;
            shortBreakDurationTextBox.Value = userPreferences.GetIntervalDuration(IntervalType.ShortBreak).Minutes;
            longBreakDurationTextBox.Value = userPreferences.GetIntervalDuration(IntervalType.LongBreak).Minutes;
            maxPomodoroCountTextBox.Value = userPreferences.MaxPomodoroCount;
        }

        private void OnCancelButtonClick(object sender, System.EventArgs e)
        {
            Close();
        }

        private void OnOkButtonClick(object sender, System.EventArgs e)
        {
            userPreferences.Update(newPreferences =>
            {
                newPreferences.SetIntervalDuration(IntervalType.Pomodoro, Duration.InMinutes((int)pomodoroDurationTextBox.Value));
                newPreferences.SetIntervalDuration(IntervalType.ShortBreak, Duration.InMinutes((int)shortBreakDurationTextBox.Value));
                newPreferences.SetIntervalDuration(IntervalType.LongBreak, Duration.InMinutes((int)longBreakDurationTextBox.Value));
                newPreferences.MaxPomodoroCount = (int)maxPomodoroCountTextBox.Value;
            });

            Close();
        }
    }
}
