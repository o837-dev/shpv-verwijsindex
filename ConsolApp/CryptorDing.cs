using System;

namespace ConsolApp
{
    class CryptorDing
    {
        public CryptorDing()
        {
            Console.Write("[E]ncrypt or [D]ecrypt? ");
            string key = Console.ReadKey().Key.ToString();
            Console.Write(Environment.NewLine);

            if (key.Equals("E", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Text to encrypt: ");
                string text = Console.ReadLine();
                Console.WriteLine(Denion.WebService.Cryptography.Rijndael.Encrypt(text));
            }
            else
            {
                Console.WriteLine("Text to decrypt: ");
                string text = Console.ReadLine();
                try
                {
                    Console.WriteLine(Denion.WebService.Cryptography.Rijndael.Decrypt(text));
                }
                catch (Exception)
                {
                }

            }
            Console.Write("Press any key...");
            Console.ReadKey();

        }
    }
}
