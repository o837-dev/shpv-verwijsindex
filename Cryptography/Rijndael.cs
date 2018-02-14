using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Denion.WebService.Cryptography
{
    /// <summary>
    /// Crypts text using base64 encoding
    /// </summary>
    public class Rijndael
    {
        private static string passPhrase = "Pas5pr@se";        // can be any string
        private static string defaultSaltValue = "s@1tValue";         // can be any string
        private static string hashAlgorithm = "SHA1";          // can be "MD5"
        private static int passwordIterations = 2;             // can be any number
        private static string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
        private static int keySize = 256;                      // can be 192 or 128

        /// <summary>
        /// Encrypts the given text
        /// </summary>
        /// <param name="plainText">text to crypt</param>
        /// <returns>encrypted base64 encoded value</returns>
        public static string Encrypt(string plainText)
        {
            return Encrypt(plainText, defaultSaltValue);
        }

        /// <summary>
        /// Encrypts the given text
        /// </summary>
        /// <param name="plainText">text to crypt</param>
        /// <returns>encrypted base64 encoded value</returns>
        public static string Encrypt(string plainText, string salt)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(salt);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();

            string cipherText = Convert.ToBase64String(cipherTextBytes);
            return cipherText;
        }

        /// <summary>
        /// Decryptes the given text
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public static string Decrypt(string cipherText)
        {
            return Decrypt(cipherText, defaultSaltValue);
        }

        /// <summary>
        /// Decryptes the given text
        /// </summary>
        /// <param name="cipherText">base64 encoded crypted text</param>
        /// <returns>uncrypted text</returns>
        public static string Decrypt(string cipherText, string salt)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(salt);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = password.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

            memoryStream.Close();
            cryptoStream.Close();

            string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
            return plainText;
        }
    }
}
