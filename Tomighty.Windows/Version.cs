using System.Diagnostics;
using System.Reflection;

namespace Tomighty.Windows
{
    internal class Version
    {
        private static string product;

        public static string Product
        {
            get
            {
                if (product == null)
                    product = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
                return product;
            }
        }
    }
}
