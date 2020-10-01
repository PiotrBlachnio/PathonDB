using System;

namespace PathonDB.Exceptions.General {
    public class InvalidQueryBeginningException : Exception {
        public InvalidQueryBeginningException() : base("Invalid beginning of the query") {}
    }
}