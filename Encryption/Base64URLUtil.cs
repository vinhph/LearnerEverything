using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encryption
{
    public class Base64URLUtil
    {
        public static string Encode(string input)
        {
            return input.Replace("+", "-").Replace("/", "_");
        }
        public static string Decode(string input)
        {
            return input.Replace("-", "+").Replace("_", "/");
        }
    }
}
