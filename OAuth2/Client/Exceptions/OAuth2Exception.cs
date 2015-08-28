using System;

namespace OAuth2.Client {
    public class OAuth2Exception : Exception {

        public OAuth2Exception()
            : base() { }

        public OAuth2Exception(string message)
            : base(message) { }

        public OAuth2Exception(string message, Exception inner)
            : base(message, inner) { }
    }
}
