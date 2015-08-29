using System;
using RestSharp;

namespace OAuth2.Client {
    /// <summary>
    /// Indicates unexpected response from service.
    /// </summary>
    public class UnexpectedResponseException : OAuth2Exception {

        /// <summary>
        /// Unexpected response itself (can be null, if error occured later in the response processing pipeline).
        /// </summary>
        public IRestResponse Response { get; private set; }

        private const string MessageTemplate = "There was a problem with the response. Status code was {0}.";

        /// <summary>
        /// Initializes a new instance of the <see cref="UnexpectedResponseException"/> class.
        /// </summary>
        /// <param name="response">The response.</param>
        public UnexpectedResponseException(IRestResponse response) 
            : base(string.Format(MessageTemplate,response.StatusCode)) {
            Response = response;
        }


    }
}