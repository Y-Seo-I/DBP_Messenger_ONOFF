using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DB_SNS
{
    class Encrypt
    {
        private static readonly string KEY = "572772257277225727722v5727722";
        //128bit(16자리)
        private static readonly string KEY_128 = KEY.Substring(0, 128 / 8);

        //AES 128 암호화 . CBC,PKCS7, 예외 발생시 null
        public static string encryptAES128(string plain)
        {
            try
            {
                byte[] plainBytes = Encoding.UTF8.GetBytes(plain);

                RijndaelManaged rm = new RijndaelManaged();
                rm.Mode = CipherMode.CBC;
                rm.Padding = PaddingMode.PKCS7;
                rm.KeySize = 128;

                MemoryStream memoryStream = new MemoryStream();

                ICryptoTransform encryptor = rm.CreateEncryptor(Encoding.UTF8.GetBytes(KEY_128), Encoding.UTF8.GetBytes(KEY_128));
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

                cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                cryptoStream.FlushFinalBlock();

                byte[] encryptBytes = memoryStream.ToArray();

                string encryptString = Convert.ToBase64String(encryptBytes);

                cryptoStream.Close();
                memoryStream.Close();

                return encryptString;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string decryptAES128(string encrypt)
        {
            try
            {
                byte[] encryptBytes = Convert.FromBase64String(encrypt);

                RijndaelManaged rm = new RijndaelManaged();

                rm.Mode = CipherMode.CBC;
                rm.Padding = PaddingMode.PKCS7;
                rm.KeySize = 128;

                MemoryStream memoryStream = new MemoryStream(encryptBytes);

                ICryptoTransform decryptor = rm.CreateDecryptor(Encoding.UTF8.GetBytes(KEY_128), Encoding.UTF8.GetBytes(KEY_128));
                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

                byte[] plainBytes = new byte[encryptBytes.Length];

                int plainCount = cryptoStream.Read(plainBytes, 0, plainBytes.Length);

                string plainString = Encoding.UTF8.GetString(plainBytes, 0, plainCount);

                cryptoStream.Close();
                memoryStream.Close();

                return plainString;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
