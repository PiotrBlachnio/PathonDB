using System;

namespace PathonDB.Exceptions.General {
    public class MalformedArgumentsException : Exception {
        public MalformedArgumentsException() : base("Query has malformed arguments") {}
    }
}