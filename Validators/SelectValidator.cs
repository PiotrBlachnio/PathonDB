using PathonDB.Models;

namespace PathonDB.Validators {
    public class SelectValidator : Validator {
        private const string QUERY_START = "SELECT ";
        private const string QUERY_END = ";";

        public SelectValidator(IDatabase database) {
            
        }
    }
}

// SELECT * FROM users;