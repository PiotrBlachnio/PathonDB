using System;

namespace PathonDB.Exceptions.General {
    public class TableNotFoundException : Exception {
        public TableNotFoundException(string table): base($"Table does not exist: \"{table}\"") {}
    }
}