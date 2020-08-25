using JsonDatabase.Middlewares;
using JsonDatabase.Middlewares.Create;

namespace JsonDatabase.Validators.Create {
    public class CreateTableValidator {
        private const string CREATE_QUERY_START = "CREATE TABLE ";
        private const string CREATE_QUERY_END = ");";

        private Middleware _middleware; 

        public CreateTableValidator() {
            _middleware = new CreateTableHasValidParameters();
        }

        public bool Validate(string query) {
            return _middleware.Check(query);
        }
    }
}