using System;

namespace JsonDatabase.Exceptions.Create {
    public class MalformedColumnsException : Exception {
        public MalformedColumnsException() : base("Query has malformed columns") {}
    }
}