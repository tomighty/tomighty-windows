namespace Tomighty.Events
{
    public class PomodoroCountChanged
    {
        public PomodoroCountChanged(int count)
        {
            PomodoroCount = count;
        }

        public int PomodoroCount { get; }
    }
}
