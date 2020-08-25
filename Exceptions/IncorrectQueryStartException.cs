using System;

namespace JsonDatabase.Exceptions {
    public class IncorrectQueryStartException : Exception {
        public IncorrectQueryStartException(string query) : base($"Incorrect start of query: {query}") {}
    }
}