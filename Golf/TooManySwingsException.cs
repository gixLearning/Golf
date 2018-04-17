using System;

namespace Golf {
    public class TooManySwingsException : Exception {
        public TooManySwingsException() {
        }

        public TooManySwingsException(string message) : base(message) {
        }

        public TooManySwingsException(string message, Exception innerException) : base(message, innerException) {
        }

        protected TooManySwingsException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) {
        }
    }
}