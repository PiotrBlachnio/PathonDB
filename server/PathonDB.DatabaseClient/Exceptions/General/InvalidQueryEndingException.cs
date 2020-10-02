using System;

namespace PathonDB.DatabaseClient.Exceptions.General {
    public class InvalidQueryEndingException : Exception {
        public InvalidQueryEndingException(string query) : base($"Incorrect end of the query: {query}") {}
    }
}