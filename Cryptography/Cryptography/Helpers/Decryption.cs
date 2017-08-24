using Cryptography.Interfaces;
using Chilkat;
using System;
using System.Text;

namespace Cryptography.Helpers
{
    class Decryption
    {

        public static string DecryptString(Crypt2 crypt, string text, int srno)
        {
            ICryptography s = CryptoManager.FactoryMethod(srno) as ICryptography;
            s.Configure(crypt);
            return crypt.DecryptStringENC(text);
        }


        public static string GetDecryptedText(string text) => text.Split('~')[0];

        public static char[] GetDateTimeTextArray(string text) => text.Split('~')[1].ToCharArray();


        public static string MultipleDecryptions(Crypt2 crypt, string decryptedText, char[] charArray)
        {
            foreach (var number in charArray)
            {
                decryptedText = DecryptString(crypt, decryptedText, Convert.ToInt32(number.ToString()));
            }
            return decryptedText;
        }


        public static string Base64ToNormalString(string base64text)
        {

            byte[] byteArray = Convert.FromBase64String(base64text);

            return Encoding.UTF8.GetString(byteArray);
        }

    }
}
