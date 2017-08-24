using Cryptography.Helpers;
using Cryptography.Interfaces;
using Chilkat;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptography.Algorithms
{
    public class TwoKey_TripleDES_112bits : ICryptography
    {
        void ICryptography.Configure(Crypt2 crypt)
        {
            crypt.UnlockComponent("Anything for 30-day trial.");

            crypt.CryptAlgorithm = "3des";

            crypt.CipherMode = "ecb";

            //  For 2-Key Triple-DES, use a key length of 128
            //  (Given that each byte's msb is a parity bit, the strength is really 112 bits).
            crypt.KeyLength = 128;

            //  Pad with zeros
            crypt.PaddingScheme = 3;

            //  EncodingMode specifies the encoding of the output for
            //  encryption, and the input for decryption.
            //  It may be "hex", "url", "base64", or "quoted-printable".
            crypt.EncodingMode = "hex";

            //  Let's create a secret key by using the MD5 hash of a password.
            //  The Digest-MD5 algorithm produces a 16-byte hash (i.e. 128 bits)
            crypt.HashAlgorithm = "md5";

            string keyHex = crypt.HashStringENC(Keys.TwoKey_TripleDES_112bits_KeyString);

            //  Set the encryption key:
            crypt.SetEncodedKey(keyHex, "hex");
            
        }
    }
}
