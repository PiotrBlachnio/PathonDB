using System;

namespace JsonDatabase.Exceptions {
    public class IncorrectParameterTypeException : Exception {
        public IncorrectParameterTypeException(string parameter, string expectedType)
            : base($"Parameter \"{parameter}\" has invalid type. Expected: \"{expectedType}\"") {}
    }
}