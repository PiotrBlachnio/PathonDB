using System;

namespace JsonDatabase.Exceptions {
    public class InvalidTableNameException : Exception {
        public InvalidTableNameException(string query): base($"Query has incorrect table name: \"{query}\"") {}
    }
}