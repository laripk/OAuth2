using System;

namespace OAuth2.Client {
    public class AuthServerException: AuthenticationException {
        public AuthServerException(string message) : base(message) { }

    }
}
