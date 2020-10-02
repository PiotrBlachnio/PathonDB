using System;

namespace PathonDB.DatabaseClient.Exceptions.General {
    public class MalformedColumnsException : Exception {
        public MalformedColumnsException() : base("Query has malformed columns") {}
    }
}