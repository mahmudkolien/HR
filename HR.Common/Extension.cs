using System;
using System.Text;

namespace HR.Common
{
    public static class Extension
    {
        public static string ToHash(this string value)
        {
            return EncryptDecrypt.GetHash(value);
        }
    }
}