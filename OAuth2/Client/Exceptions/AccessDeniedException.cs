namespace OAuth2.Client {
    public class AccessDeniedException : AuthenticationException {
        public AccessDeniedException() : base() { }

        public override string Message {
            get {
                return "The user denied the authorization request.";
            }
        }
    }
}
