using System;

namespace JsonDatabase.Exceptions {
    public class MalformedColumnsException : Exception {
        public MalformedColumnsException() : base("Query has malformed columns") {}
    }
}