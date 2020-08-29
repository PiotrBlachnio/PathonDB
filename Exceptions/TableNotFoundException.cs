using System;

namespace JsonDatabase.Exceptions {
    public class TableNotFoundException : Exception {
        public TableNotFoundException(string table): base($"Table does not exist: \"{table}\"") {}
    }
}