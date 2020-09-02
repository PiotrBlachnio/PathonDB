using System;

namespace JsonDatabase.Exceptions.Insert {
    public class InvalidColumnNumberException : Exception {
        public InvalidColumnNumberException(int actual, int expected) : base($"Expected column number: {expected}, received: {actual}") {}
    }
}