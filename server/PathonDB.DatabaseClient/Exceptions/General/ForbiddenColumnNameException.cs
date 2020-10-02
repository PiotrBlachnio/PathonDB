using System;

namespace PathonDB.DatabaseClient.Exceptions.General {
    public class ForbiddenColumnNameException : Exception {
        public ForbiddenColumnNameException(string columnName) : base($"Column name \"{columnName}\" is not allowed") {}
    }
}