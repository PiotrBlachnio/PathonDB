using System;

namespace JsonDatabase.Exceptions {
    public class IncorrectPropertyTypeException : Exception {
        public IncorrectPropertyTypeException(string propertyName, string expectedType, string actualType)
            : base($"Property \"{propertyName}\" has type \"{expectedType}\" but received type is \"{actualType}\"") {}
    }
}