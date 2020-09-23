using System;

namespace PathonDB.Exceptions.General {
    public class InvalidColumnTypeException : Exception {
        public InvalidColumnTypeException(string columnName, string expectedType)
            : base($"Column \"{columnName}\" has invalid type. Expected: \"{expectedType}\"") {}
    }
}