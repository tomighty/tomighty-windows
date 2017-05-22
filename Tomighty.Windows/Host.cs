//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System;
using System.IO;
using System.Management;
using Tomighty.Windows.Util;

namespace Tomighty.Windows
{
    internal class Host
    {
        private static string id;

        public static string Id
        {
            get
            {
                if (id == null) id = GetId();
                return id;
            }
        }

        private static string GetId()
        {
            try
            {
                return ComputeId();
            }
            catch
            {
                try
                {
                   return GenerateId();
                }
                catch
                {
                    return "undefined";
                }
            }
        }

        private static string GenerateId()
        {
            string uuid = null;
            var path = Path.Combine(Directories.AppData, "machine_id");

            if (File.Exists(path))
                uuid = File.ReadAllText(path);
            
            if (uuid == null || uuid.Length != Guid.Empty.ToString().Length)
            {
                uuid = Guid.NewGuid().ToString();
                File.WriteAllText(path, uuid);
            }

            return uuid;
        }

        private static string ComputeId()
        {
            var mgmt = new ManagementClass("win32_processor");
            var data = "";
            foreach (ManagementObject mo in mgmt.GetInstances())
                data += GetProcessorInfo(mo);
            return Hash.Sha1(data);
        }

        private static string GetProcessorInfo(ManagementObject mo)
        {
            return "[" +
                mo.Properties["processorID"].Value + "|" +
                mo.Properties["Architecture"].Value + "|" +
                mo.Properties["Family"].Value + "|" +
                mo.Properties["Caption"].Value + "]";
        }
    }
}
