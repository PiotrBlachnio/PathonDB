using System;

namespace JsonDatabase.Exceptions.General {
    public class TableNotFoundException : Exception {
        public TableNotFoundException(string table): base($"Table does not exist: \"{table}\"") {}
    }
}