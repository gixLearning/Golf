using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf {
    public class TooFarAwayException : Exception {
        public TooFarAwayException() {
        }

        public TooFarAwayException(string message) : base(message) {
        }

        public TooFarAwayException(string message, Exception innerException) : base(message, innerException) {
        }

        protected TooFarAwayException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) {
        }
    }
}
