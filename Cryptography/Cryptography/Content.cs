using Cryptography.Helpers;

namespace Cryptography
{
    public sealed class Content
    {
        public static string Encrypt(string text)
        {
            return CryptoManager.Instance.Encrypt(text);
        }



        public static string Decrypt(string text)
        {
            return CryptoManager.Instance.Decrypt(text);
        }
    }
}
