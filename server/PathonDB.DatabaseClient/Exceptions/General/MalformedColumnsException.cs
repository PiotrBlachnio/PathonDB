using System;

namespace PathonDB.Exceptions.General {
    public class MalformedColumnsException : Exception {
        public MalformedColumnsException() : base("Query has malformed columns") {}
    }
}