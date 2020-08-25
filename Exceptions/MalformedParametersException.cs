using System;

namespace JsonDatabase.Exceptions {
    public class MalformedParametersException : Exception {
        public MalformedParametersException() : base($"Query has malformed parameters") {}
    }
}