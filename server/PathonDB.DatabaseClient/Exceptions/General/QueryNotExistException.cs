using System;

namespace PathonDB.DatabaseClient.Exceptions.General {
    public class QueryNotExistException : Exception {
        public QueryNotExistException() : base("Query does not exist") {}
    }
}