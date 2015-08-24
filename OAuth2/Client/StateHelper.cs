using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jose;
using Jose.jwe;


namespace OAuth2.Client {

    /// <summary>
    /// Helper for packing data into JWT tokens (for the State parameter)
    /// and for validating and unpacking the data out again.
    /// </summary>
    public static class StateHelper {

        /// <summary>
        /// Packs a set of key-value pairs into an unprotected JWT token.
        /// </summary>
        /// <param name="yourdata">The set of key-value pairs you want to pack. 
        /// Should be translatable into Dictionary<string, object></param>
        /// <returns></returns>
        public static string Pack(object yourdata) {
            string token = JWT.Encode(yourdata, null, JwsAlgorithm.none);
            return token;
        }


        /// <summary>
        /// Packs a set of key-value pairs into an encrypted JWT token.
        /// Uses the AES Key Wrap Algorithm using 256 bit keys (RFC 3394)
        /// with AES_256_CBC_HMAC_SHA_512 authenticated encryption using a 512 bit key.
        /// </summary>
        /// <param name="yourdata">The set of key-value pairs you want to pack. 
        /// Should be translatable into Dictionary<string, object></param>
        /// <param name="secretKey">A passphrase from which the key will be derived.</param>
        /// <returns></returns>
        public static string Pack(object yourdata, string secretKey) {
            string token = Jose.JWT.Encode(yourdata, secretKey, JweAlgorithm.A256KW, JweEncryption.A256CBC_HS512);
            return token;
        }


        /// <summary>
        /// Unpacks a JWT token into raw JSON.
        /// </summary>
        /// <param name="token">The JWT toekn.</param>
        /// <param name="secretKey">The decryption key. Leave null if unencrypted.</param>
        /// <returns>The raw JSON of the original key-value pairs.</returns>
        public static string Unpack(string token, string secretKey = null) {
            string json = JWT.Decode(token, secretKey);
            return json;
        }
    }
}
