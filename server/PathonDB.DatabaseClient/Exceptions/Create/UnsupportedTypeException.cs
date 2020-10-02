using System;

namespace PathonDB.DatabaseClient.Exceptions.Create {
    public class UnsupportedTypeException : Exception {
        public UnsupportedTypeException(string type) : base($"Unsupported type found in query: {type}") {}
    }
}