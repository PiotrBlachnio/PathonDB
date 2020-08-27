using System;

namespace JsonDatabase.Exceptions {
    public class InvalidQueryTypeException : Exception {
        public InvalidQueryTypeException(string queryType) : base($"Incorrect query type: \"{queryType}\"") {}
    }
}