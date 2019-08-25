using System;
using System.Text;

namespace HR.Common
{
    public static class EncryptDecrypt
    {
        public static string GetHash(string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create()
                    .ComputeHash(Encoding.UTF8.GetBytes(value))
            );
        }
    }
}