using System;


namespace OAuth2.Client {
    public class AuthenticationException : OAuth2Exception {

        protected AuthenticationException() : base() { }

        protected AuthenticationException(string message) : base(message) { }

        protected static string MakeMessage(string errorType, string errorDescription = "", string errorUrl = "", string prefix = "Error") {
            string m = string.Format("{0} {1} occurred.", prefix, errorType);
            if (!string.IsNullOrWhiteSpace(errorDescription)) {
                m += string.Format(" Details: {0}", errorDescription);
            }
            if (!string.IsNullOrWhiteSpace(errorUrl)) {
                m += string.Format(" See {0} for more information.", errorUrl);
            }
            return m;
        }

        public static AuthenticationException Factory(string errorType, string errorDescription = "", string errorUrl = "") {
            switch (errorType) {
                case "access_denied":
                    return new AccessDeniedException();
                case "server_error":
                case "temporarily_unavailable":
                    return new AuthServerException(MakeMessage(errorType, errorDescription, errorUrl, "Server problem"));
                default:
                    return new AuthenticationException(MakeMessage(errorType, errorDescription, errorUrl));
            }
        }

    }
}
