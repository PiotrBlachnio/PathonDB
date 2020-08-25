using System;

namespace JsonDatabase.Exceptions {
    public class GenericException : Exception {
        public new string Message;

        public GenericException(string message) {
            this.Message = message;
        }
    }
}