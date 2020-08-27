using System;

namespace JsonDatabase.Exceptions {
    public class UnsupportedTypeException : Exception {
        public UnsupportedTypeException(string type) : base($"Unsupported type found in query: {type}") {}
    }
}