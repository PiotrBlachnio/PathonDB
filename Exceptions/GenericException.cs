using System;

namespace JsonDatabase.Exceptions {
    public abstract class GenericException : Exception {
        protected new string Message = "";
    }
}