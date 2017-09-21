using Cryptography.Interfaces;
using Chilkat;
using System;
using System.Linq;
using System.Text;

namespace Cryptography.Helpers
{
    internal class Decryption
    {

        public static string DecryptString(Crypt2 crypt, string text, int srno)
        {
            var s = CryptoManager.FactoryMethod(srno) as ICryptography;
            s.Configure(crypt);
            return crypt.DecryptStringENC(text);
        }


        public static string GetDecryptedText(string text) => text.Split('~')[0];

        public static char[] GetDateTimeTextArray(string text) => text.Split('~')[1].ToCharArray();


        public static string MultipleDecryptions(Crypt2 crypt, string decryptedText, char[] charArray)
        {
            return charArray.Aggregate(decryptedText, (current, number) => DecryptString(crypt, current, Convert.ToInt32(number.ToString())));
        }


        public static string Base64ToNormalString(string base64text)
        {

            var byteArray = Convert.FromBase64String(base64text);

            return Encoding.UTF8.GetString(byteArray);
        }

    }
}
