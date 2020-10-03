using System;

namespace PathonDB.DatabaseClient.Exceptions.General {
    public class QueryNotExist : Exception {
        public QueryNotExist() : base("Query does not exist") {}
    }
}