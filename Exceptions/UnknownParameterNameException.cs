using System;

namespace JsonDatabase.Exceptions {
    public class UnknownColumnNameException : Exception {
        public UnknownColumnNameException(string columnName) : base($"Unknown column: {columnName}") {}
    }
}