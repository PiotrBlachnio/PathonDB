using System;

namespace JsonDatabase.Exceptions {
    public class TableAlreadyExistsException : Exception {
        public TableAlreadyExistsException(string table): base($"Table already exist: \"{table}\"") {}
    }
}