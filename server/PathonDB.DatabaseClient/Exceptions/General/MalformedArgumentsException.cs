using System;

namespace PathonDB.DatabaseClient.Exceptions.General {
    public class MalformedArgumentsException : Exception {
        public MalformedArgumentsException() : base("Query has malformed arguments") {}
    }
}