using Cryptography.Helpers;
using Cryptography.Interfaces;
using Chilkat;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptography.Algorithms
{
    class Twofish : ICryptography
    {
        public void Configure(Crypt2 crypt)
        {
            crypt.UnlockComponent("Anything for 30-day trial.");

            //  Set the encryption algorithm = "twofish"
            crypt.CryptAlgorithm = "twofish";

            //  CipherMode may be "ecb" or "cbc"
            crypt.CipherMode = "cbc";

            //  KeyLength may be 128, 192, 256
            crypt.KeyLength = 256;

            //  The padding scheme determines the contents of the bytes
            //  that are added to pad the result to a multiple of the
            //  encryption algorithm's block size.  Twofish has a block
            //  size of 16 bytes, so encrypted output is always
            //  a multiple of 16.
            crypt.PaddingScheme = 0;

            //  EncodingMode specifies the encoding of the output for
            //  encryption, and the input for decryption.
            //  It may be "hex", "url", "base64", or "quoted-printable".
            crypt.EncodingMode = "hex";

            //  An initialization vector is required if using CBC mode.
            //  ECB mode does not use an IV.
            //  The length of the IV is equal to the algorithm's block size.
            //  It is NOT equal to the length of the key.
            string ivHex = "000102030405060708090A0B0C0D0E0F";
            crypt.SetEncodedIV(ivHex, "hex");

            //  The secret key must equal the size of the key.  For
            //  256-bit encryption, the binary secret key is 32 bytes.
            //  For 128-bit encryption, the binary secret key is 16 bytes.
            string keyHex = Keys.Twofish_KeyString;

            crypt.SetEncodedKey(keyHex, "hex");
        }
    }
}
