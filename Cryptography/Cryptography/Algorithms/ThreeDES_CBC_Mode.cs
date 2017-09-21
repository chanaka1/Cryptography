using System;
using Chilkat;
using Cryptography.Interfaces;
using Cryptography.Helpers;

namespace Cryptography.Algorithms
{
    class ThreeDES_CBC_Mode : ICryptography
    {
        public void Configure(Crypt2 crypt)
        {
            crypt.UnlockComponent("Anything for 30-day trial.");


            //  Specify 3DES for the encryption algorithm:
            crypt.CryptAlgorithm = "3des";

            //  CipherMode may be "ecb" or "cbc"
            crypt.CipherMode = "cbc";

            //  KeyLength must be 192.  3DES is technically 168-bits;
            //  the most-significant bit of each key byte is a parity bit,
            //  so we must indicate a KeyLength of 192, which includes
            //  the parity bits.
            crypt.KeyLength = 192;

            //  The padding scheme determines the contents of the bytes
            //  that are added to pad the result to a multiple of the
            //  encryption algorithm's block size.  3DES has a block
            //  size of 8 bytes, so encrypted output is always
            //  a multiple of 8.
            crypt.PaddingScheme = 0;

            //  EncodingMode specifies the encoding of the output for
            //  encryption, and the input for decryption.
            //  It may be "hex", "url", "base64", or "quoted-printable".
            crypt.EncodingMode = "hex";

            //  An initialization vector is required if using CBC or CFB modes.
            //  ECB mode does not use an IV.
            //  The length of the IV is equal to the algorithm's block size.
            //  It is NOT equal to the length of the key.
            const string ivHex = "0001020304050607";
            crypt.SetEncodedIV(ivHex, "hex");

            //  The secret key must equal the size of the key.  For
            //  3DES, the key must be 24 bytes (i.e. 192-bits).
            var keyHex = Keys.ThreeDES_CBC_Mode_KeyString;

            crypt.SetEncodedKey(keyHex, "hex");

        }
    }
}
