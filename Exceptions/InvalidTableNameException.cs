using System;

namespace JsonDatabase.Exceptions {
    public class InvalidTableNameException : Exception {
        public InvalidTableNameException(string table): base($"Query has incorrect table name: \"{table}\"") {}
    }
}