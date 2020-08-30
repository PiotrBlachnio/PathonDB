using System;

namespace JsonDatabase.Exceptions {
    public class UnknownParameterNameException : Exception {
        public UnknownParameterNameException(string parameter) : base($"Unknown parameter: {parameter}") {}
    }
}