using Cryptography.Helpers;
using Cryptography.Interfaces;
using Chilkat;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptography.Algorithms
{
    class RC2_ECB : ICryptography
    {
        public void Configure(Crypt2 crypt)
        {
            crypt.UnlockComponent("Anything for 30-day trial.");


            //  Set the encryption algorithm = "rc2"
            crypt.CryptAlgorithm = "rc2";

            //  CipherMode may be "ecb" or "cbc"
            crypt.CipherMode = "ecb";

            //  KeyLength may range from 8 bits to 1024 bits
            crypt.KeyLength = 128;

            //  RC2 also has an effective key length property
            //  which can also range from 8 bits to 1024 bits:
            crypt.Rc2EffectiveKeyLength = 128;

            //  The padding scheme determines the contents of the bytes
            //  that are added to pad the result to a multiple of the
            //  encryption algorithm's block size.  RC2 has a block
            //  size of 8 bytes, so encrypted output is always
            //  a multiple of 8.
            crypt.PaddingScheme = 0;

            //  EncodingMode specifies the encoding of the output for
            //  encryption, and the input for decryption.
            //  It may be "hex", "url", "base64", or "quoted-printable".
            crypt.EncodingMode = "hex";

            //  An initialization vector is required if using CBC mode.
            //  ECB mode does not use an IV.
            //  The length of the IV is equal to the algorithm's block size.
            //  It is NOT equal to the length of the key.
            string ivHex = "0001020304050607";
            crypt.SetEncodedIV(ivHex, "hex");

            //  The secret key must equal the size of the key.
            //  For 128-bit encryption, the binary secret key is 16 bytes.
            string keyHex = Keys.RC2_ECB_KeyString;

            crypt.SetEncodedKey(keyHex, "hex");

        }
    }
}
