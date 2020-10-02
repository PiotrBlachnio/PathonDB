using System;

namespace PathonDB.Exceptions.Create {
    public class ForbiddenTableNameException : Exception {
        public ForbiddenTableNameException(string table) : base($"Table name \"{table}\" is not allowed") {}
    }
}