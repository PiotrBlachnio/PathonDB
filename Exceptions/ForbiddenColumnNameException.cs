using System;

namespace JsonDatabase.Exceptions {
    public class ForbiddenColumnNameException : Exception {
        public ForbiddenColumnNameException(string columnName) : base($"Column name \"{columnName}\" is not allowed") {}
    }
}