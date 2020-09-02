using System;

namespace JsonDatabase.Exceptions.General {
    public class MalformedArgumentsException : Exception {
        public MalformedArgumentsException() : base("Query has malformed arguments") {}
    }
}