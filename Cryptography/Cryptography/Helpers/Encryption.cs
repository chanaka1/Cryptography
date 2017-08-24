using Cryptography.Interfaces;
using Chilkat;
using System;
using System.Text;

namespace Cryptography.Helpers
{
    class Encryption
    {
        public static string EncryptString(Crypt2 crypt,string text, int srno)
        {
            ICryptography s = CryptoManager.FactoryMethod(srno) as ICryptography;
            s.Configure(crypt);
            return crypt.EncryptStringENC(text);
        }


        public static string TextFormatter(string encryptedtext, string dateTime)
        {
            return encryptedtext + "~" + dateTime;
        }

        public static string MultipleEncryptions(Crypt2 crypt, string encryptedtext, char[] charArray)
        {
            foreach (var number in charArray)
            {
                encryptedtext = EncryptString(crypt, encryptedtext, Convert.ToInt32(number.ToString()));
            }
            return encryptedtext;
        }

        public static string ToBase64String(string encryptedtext)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(encryptedtext);
            return Convert.ToBase64String(byteArray);
        }

    }
}
