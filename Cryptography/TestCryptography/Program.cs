using Cryptography;
using System;
using System.Diagnostics;

namespace TestCryptography
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string str = "SensitiveData";
            Console.WriteLine("String To Encrypt : "+str);

            var sw_encryption = new Stopwatch();

            sw_encryption.Start();
            var encrypt = Content.Encrypt(str);
            sw_encryption.Stop();

            Console.WriteLine("Time taken to encrypt  : " + sw_encryption.ElapsedMilliseconds + " milliseconds");

            Console.WriteLine(" ");
            Console.WriteLine("Encrypted String : " + encrypt);
            Console.WriteLine(" ");
            Console.WriteLine("Encrypted String Length : " + encrypt.Length);
            Console.WriteLine(" ");



            var sw_decryption = new Stopwatch();

            sw_decryption.Start();
            var decrypt = Content.Decrypt(encrypt);
            sw_decryption.Stop();

            Console.WriteLine("Decrypted String : " + decrypt);

            Console.WriteLine("Time taken to decrypt : " + sw_decryption.ElapsedMilliseconds + " milliseconds");

            Console.ReadKey();

        }
    }
}