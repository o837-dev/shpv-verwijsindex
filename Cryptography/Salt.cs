using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Denion.WebService.Cryptography
{
    public class Salt
    {
        public static string GetSalt(int length)
        {
            //Create and populate random byte array
            byte[] randomArray = new byte[length];
            string randomString;

            //Create random salt and convert to string
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomArray);
            randomString = Convert.ToBase64String(randomArray);

            return randomString;
        }
    }
}
