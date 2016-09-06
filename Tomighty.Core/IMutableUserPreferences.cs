namespace Tomighty
{
    public interface IMutableUserPreferences : IUserPreferences
    {
        void SetIntervalDuration(IntervalType intervalType, Duration duration);
        new int MaxPomodoroCount { get; set; }
    }
}
