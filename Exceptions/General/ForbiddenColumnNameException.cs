using System;

namespace JsonDatabase.Exceptions.General {
    public class ForbiddenColumnNameException : Exception {
        public ForbiddenColumnNameException(string columnName) : base($"Column name \"{columnName}\" is not allowed") {}
    }
}