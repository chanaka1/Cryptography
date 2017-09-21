using Cryptography.Algorithms;
using Cryptography.Interfaces;
using Chilkat;
using System;

namespace Cryptography.Helpers
{
    public sealed class CryptoManager
    {
        private static volatile CryptoManager instance;
        private static Crypt2 _crypt;
        private static readonly object syncRoot = new object();
        private readonly string _dateTime = DateTime.Now.ToString("dhmsf");


        private CryptoManager() { }


        //This approach ensures that only one instance is created and only when the instance is needed.
        //Also, the variable is declared to be volatile to ensure that assignment to the instance variable 
        //completes before the instance variable can be accessed.
        //Lastly, this approach uses a syncRoot instance to lock on, rather than locking on the type itself, to avoid deadlocks.
        //This double-check locking approach solves the thread concurrency problems while avoiding an 
        //exclusive lock in every call to the Instance property method.It also allows you to delay instantiation
        //until the object is first accessed. In practice, an application rarely requires this type of implementation.
        public static CryptoManager Instance
        {
            get
            {
                if (instance != null) return instance;

                lock (syncRoot)
                {
                    if (instance != null) return instance;

                    instance = new CryptoManager();
                    _crypt = Crypt.Instance;
                }

                return instance;
            }
        }


        public string Encrypt(string text)
        {
            var arr = _dateTime.ToCharArray();
            var encryptedtext = Encryption.MultipleEncryptions(_crypt, text, arr);
            encryptedtext = Encryption.TextFormatter(encryptedtext, _dateTime.ToString());
            return Encryption.ToBase64String(encryptedtext);
        }



        public string Decrypt(string text)
        {
            text = Decryption.Base64ToNormalString(text);
            var decryptedText = Decryption.GetDecryptedText(text);
            var arr = Decryption.GetDateTimeTextArray(text);
            Array.Reverse(arr);
            decryptedText = Decryption.MultipleDecryptions(_crypt, decryptedText, arr);
            return decryptedText;
        }
        
        public  static object FactoryMethod(int srno)
        {
            ICryptography cryptoObj;

            switch (srno)
            {
                case 0:
                    cryptoObj = new AES();
                    break;

                case 1:
                    cryptoObj = new ARC4();
                    break;

                case 2:
                    cryptoObj = new Blowfish_CBC();
                    break;

                case 3:
                    cryptoObj = new Blowfish_CFB();
                    break;

                case 4:
                    cryptoObj = new Blowfish_ECB();
                    break;

                case 5:
                    cryptoObj = new ChaCha20();
                    break;

                case 6:
                    cryptoObj = new RC2_CBC();
                    break;

                case 7:
                    cryptoObj = new RC2_ECB();
                    break;

                case 8:
                    cryptoObj = new ThreeDES_CBC_Mode();
                    break;

                case 9:
                    cryptoObj = new ThreeDES_ECB_Mode();
                    break;

                default:
                    cryptoObj = null;
                    break;
            }

            return cryptoObj;
        }

    }



}
