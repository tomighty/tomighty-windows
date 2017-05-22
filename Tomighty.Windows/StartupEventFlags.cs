namespace Tomighty.Windows
{
    public class StartupEventFlags
    {
        public static readonly Flags Flags = new Flags("startup");
        public static readonly string FirstRunFlag = "firstrun";
        public static readonly string AppUpdatedFlag = "app_updated";
    }
}
