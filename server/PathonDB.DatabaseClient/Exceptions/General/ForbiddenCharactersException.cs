using System;

namespace PathonDB.Exceptions.General {
    public class ForbiddenCharactersException : Exception {
        public ForbiddenCharactersException(string value) : base($"Query contains forbidden characters: \"{value}\"") {}
    }
}