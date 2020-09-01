using System;

namespace JsonDatabase.Exceptions.General {
    public class InvalidQueryEndingException : Exception {
        public InvalidQueryEndingException(string query) : base($"Incorrect end of the query: {query}") {}
    }
}