using Cryptography;
using System;
using System.Diagnostics;

namespace TestCryptography
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "SensitiveData";
            Console.WriteLine("String To Encrypt : "+str);

            Stopwatch sw_encryption = new Stopwatch();

            sw_encryption.Start();
            string encrypt = Content.Encrypt(str);
            sw_encryption.Stop();

            Console.WriteLine("Time taken to encrypt  : " + sw_encryption.ElapsedMilliseconds + " milliseconds");

            Console.WriteLine(" ");
            Console.WriteLine("Encrypted String : " + encrypt);
            Console.WriteLine(" ");
            Console.WriteLine("Encrypted String Length : " + encrypt.Length);
            Console.WriteLine(" ");



            Stopwatch sw_decryption = new Stopwatch();

            sw_decryption.Start();
            string decrypt = Content.Decrypt(encrypt);
            sw_decryption.Stop();

            Console.WriteLine("Decrypted String : " + decrypt);

            Console.WriteLine("Time taken to decrypt : " + sw_decryption.ElapsedMilliseconds + " milliseconds");

            Console.ReadKey();

        }
    }
}