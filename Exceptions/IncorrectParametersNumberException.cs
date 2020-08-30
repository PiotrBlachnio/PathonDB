using System;

namespace JsonDatabase.Exceptions {
    public class IncorrectParametersNumberException : Exception {
        public IncorrectParametersNumberException(int actual, int expected) : base($"Expected parameters number: {expected}, received: {actual}") {}
    }
}