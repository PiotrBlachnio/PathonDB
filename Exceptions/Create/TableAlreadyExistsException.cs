using System;

namespace JsonDatabase.Exceptions.Create {
    public class TableAlreadyExistsException : Exception {
        public TableAlreadyExistsException(string table): base($"Table already exist: \"{table}\"") {}
    }
}