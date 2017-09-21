using Cryptography.Interfaces;
using Chilkat;
using System;
using System.Linq;
using System.Text;

namespace Cryptography.Helpers
{
    internal class Encryption
    {
        public static string EncryptString(Crypt2 crypt,string text, int srno)
        {
            var s = CryptoManager.FactoryMethod(srno) as ICryptography;
            s?.Configure(crypt);
            return crypt.EncryptStringENC(text);
        }


        public static string TextFormatter(string encryptedtext, string dateTime)
        {
            return encryptedtext + "~" + dateTime;
        }

        public static string MultipleEncryptions(Crypt2 crypt, string encryptedtext, char[] charArray)
        {
            return charArray.Aggregate(encryptedtext, (current, number) => EncryptString(crypt, current, Convert.ToInt32(number.ToString())));
        }

        public static string ToBase64String(string encryptedtext)
        {
            var byteArray = Encoding.ASCII.GetBytes(encryptedtext);
            return Convert.ToBase64String(byteArray);
        }

    }
}
