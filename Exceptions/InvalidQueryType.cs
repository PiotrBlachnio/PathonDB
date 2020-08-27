using System;

namespace JsonDatabase.Exceptions {
    public class InvalidQueryType : Exception {
        public InvalidQueryType(string queryType) : base($"Incorrect query type: {queryType}") {}
    }
}