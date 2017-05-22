//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System;
using System.IO;
using System.Reflection;

namespace Tomighty.Windows
{
    internal class Directories
    {
        public static string ProgramLocation => Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        public static string AppData
        {
            get
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Tomighty");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                return path;
            }
        }
    }
}
