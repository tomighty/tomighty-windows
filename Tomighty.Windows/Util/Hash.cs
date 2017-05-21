//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

using System;
using System.Security.Cryptography;
using System.Text;

namespace Tomighty.Windows.Util
{
    public class Hash
    {
        public static string Sha1(string s)
        {
            var sha = new SHA1CryptoServiceProvider();
            var data = Encoding.UTF8.GetBytes(s);
            var hash = sha.ComputeHash(data);
            return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
        }
    }
}
