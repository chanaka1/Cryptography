using Cryptography.Helpers;
using Cryptography.Interfaces;
using Chilkat;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptography.Algorithms
{
    class ARC4 : ICryptography
    {
        public void Configure(Crypt2 crypt)
        {
            crypt.UnlockComponent("Anything for 30-day trial.");

            
            //  Set the encryption algorithm = "arc4"
            crypt.CryptAlgorithm = "arc4";

            //  KeyLength may range from 1 byte to 256 bytes.
            //  (i.e. 8 bits to 2048 bits)
            //  ARC4 key sizes are typically in the range of
            //  40 to 128 bits.
            //  The KeyLength property is specified in bits:
            crypt.KeyLength = 128;

            //  Note: The PaddingScheme and CipherMode properties
            //  do not apply w/ ARC4.  ARC4 does not encrypt in blocks --
            //  it is a streaming encryption algorithm. The number of output bytes
            //  is exactly equal to the number of input bytes.

            //  EncodingMode specifies the encoding of the output for
            //  encryption, and the input for decryption.
            //  It may be "hex", "url", "base64", or "quoted-printable".
            crypt.EncodingMode = "hex";

            //  Note: ARC4 does not utilize initialization vectors.  IV's only
            //  apply to block encryption algorithms.

            //  The secret key must equal the size of the key.
            //  For 128-bit encryption, the binary secret key is 16 bytes.
            string keyHex = Keys.ARC4_KeyString;

            crypt.SetEncodedKey(keyHex, "hex");

        }
    }
}
