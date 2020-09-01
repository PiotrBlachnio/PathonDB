using System;

namespace JsonDatabase.Exceptions.General {
    public class MalformedColumnsException : Exception {
        public MalformedColumnsException() : base("Query has malformed columns") {}
    }
}