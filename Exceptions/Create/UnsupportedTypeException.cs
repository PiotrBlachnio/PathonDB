using System;

namespace PathonDB.Exceptions.Create {
    public class UnsupportedTypeException : Exception {
        public UnsupportedTypeException(string type) : base($"Unsupported type found in query: {type}") {}
    }
}