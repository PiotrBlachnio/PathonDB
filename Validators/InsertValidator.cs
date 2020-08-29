using JsonDatabase.Models;

namespace JsonDatabase.Validators {
    public class InsertValidator : Validator {
        private const string QUERY_START = "INSERT INTO";
        private const string QUERY_END = ");";

        public InsertValidator(Database database) {
            
        }
    }
}