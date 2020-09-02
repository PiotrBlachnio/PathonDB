using System;

namespace JsonDatabase.Exceptions.General {
    public class UnknownColumnNameException : Exception {
        public UnknownColumnNameException(string columnName) : base($"Unknown column: {columnName}") {}
    }
}