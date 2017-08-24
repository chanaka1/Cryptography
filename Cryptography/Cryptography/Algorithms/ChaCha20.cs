using Cryptography.Helpers;
using Cryptography.Interfaces;
using Chilkat;

namespace Cryptography.Algorithms
{
    class ChaCha20 : ICryptography
    {
        public void Configure(Crypt2 crypt)
        {
            crypt.UnlockComponent("Anything for 30-day trial.");



            //  Set the encryption algorithm to chacha20
            //  chacha20 is a stream cipher, and therefore no cipher mode applies.
            crypt.CryptAlgorithm = "chacha20";

            //  The key length for chacha20 is always 256-bits.
            crypt.KeyLength = 256;

            //  Note: "padding" only applies to block encryption algorithmns.
            //  Since chacha20 is a stream cipher, there is no padding and the output
            //  number of bytes is exactly equal to the input.

            //  EncodingMode specifies the encoding of the output for
            //  encryption, and the input for decryption.
            //  Valid modes are (case insensitive) "Base64", "modBase64", "Base32", "Base58", "UU",
            //  "QP" (for quoted-printable), "URL" (for url-encoding), "Hex",
            //  "Q", "B", "url_oauth", "url_rfc1738", "url_rfc2396", and "url_rfc3986".
            crypt.EncodingMode = "hex";

            //  The inputs to ChaCha20 encryption, specified by RFC 7539, are:
            //  1) A 256-bit secret key.
            //  2) A 96-bit nonce.
            //  3) A 32-bit initial count.
            //  The IV property is used to specify the chacha20 nonce.
            //  For a 96-bit nonce, the IV should be 12 bytes in length.
            // 
            //  Note: Some implementations of chacha20, such as that used internally by SSH,
            //  use a 64-bit nonce and 64-bit count.  To do chacha20 encryption in this way,
            //  simply provide 8 bytes for the IV instead of 12 bytes.  Chilkat will then automatically
            //  use 8 bytes (64-bits) for the count.

            //  This example duplicates Test Vector #3 (for ChaCha20 encryption) from RFC 7539.
            string ivHex = "000000000000000000000002";
            crypt.SetEncodedIV(ivHex, "hex");

            crypt.InitialCount = 42;

            string keyHex = Keys.ChaCha20_KeyString;

            crypt.SetEncodedKey(keyHex, "hex");

        }
    }
}
