using System;

namespace OAuth2.Client {
    public class MissingValueException : OAuth2Exception {
        /// <summary>
        /// Name of field which contains unexpected (GET) response.
        /// </summary>
        public string FieldName { get; set; }

        private const string MessageTemplate = "Field '{0}' should not be empty but it is.";

        /// <summary>
        /// Initializes a new instance of the <see cref="MissingValueException"/> class.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        public MissingValueException(string fieldName) 
            : base(string.Format(MessageTemplate, fieldName)) {
            FieldName = fieldName;
        }

    }
}
