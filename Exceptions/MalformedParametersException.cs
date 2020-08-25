using System;

namespace JsonDatabase.Exceptions {
    public class MalformedParametersException : Exception {
        public MalformedParametersException(string query) : base($"Query has malformed parameters: \"{query}\"") {}
    }
}