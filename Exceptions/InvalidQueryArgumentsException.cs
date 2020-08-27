using System;

namespace JsonDatabase.Exceptions {
    public class InvalidQueryArgumentsException : Exception {
        public InvalidQueryArgumentsException(string argument) : base($"Incorrect query argument: \"{argument}\"") {}
    }
}