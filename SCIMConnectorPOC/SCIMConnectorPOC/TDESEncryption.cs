using System;
using System.Security.Cryptography;
using System.Text;

namespace SCIMConnectorPOC
{
    public class TDESEncryption
    {

        private static byte[] keyBytes = new byte[] { 2, 5, 7, 8, 4, 2, 1, 0, 2, 3, 2, 3, 2, 34, 5, 45, 5, 4, 51, 4, 1, 2, 12, 1 };
        private static byte[] IVbytes = new byte[] { 2, 5, 7, 8, 4, 2, 1, 0 };
        /// <summary>
        /// Triple DES with IV and Key
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        static byte[] encrypt(byte[] bytes)
        {
            TripleDESCryptoServiceProvider tds = new TripleDESCryptoServiceProvider();

            tds.IV = IVbytes;
            tds.Key = keyBytes;
            tds.Mode = CipherMode.ECB;
            ICryptoTransform transform = tds.CreateEncryptor();
            return transform.TransformFinalBlock(bytes, 0, bytes.Length);
        }
        static byte[] decrypt(byte[] bytes)
        {
            TripleDESCryptoServiceProvider tds = new TripleDESCryptoServiceProvider();
            tds.IV = IVbytes;
            tds.Key = keyBytes;
            tds.Mode = CipherMode.ECB;
            ICryptoTransform transform = tds.CreateDecryptor();
            return transform.TransformFinalBlock(bytes, 0, bytes.Length);
        }

        public static string encryptString(string enStr)
        {
            byte[] bytes = encrypt(Encoding.UTF8.GetBytes(enStr));
            return Convert.ToBase64String(bytes);
        }

        public static string decryptString(string deStr)
        {
            byte[] bytes = decrypt(Convert.FromBase64String(deStr));
            return Encoding.UTF8.GetString(bytes);
        }

    }
}
