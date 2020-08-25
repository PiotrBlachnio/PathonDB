using System;

namespace JsonDatabase.Exceptions {
    public class IncorrectQueryEndException : Exception {
        public IncorrectQueryEndException(string query) : base($"Incorrect end of the query: {query}") {}
    }
}