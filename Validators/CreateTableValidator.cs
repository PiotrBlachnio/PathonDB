using JsonDatabase.Middlewares.General;
using JsonDatabase.Middlewares.Create;

namespace JsonDatabase.Validators.Create {
    public class CreateTableValidator {
        private const string CREATE_QUERY_START = "CREATE TABLE ";
        private const string CREATE_QUERY_END = ");";

        private Middleware _middleware = new QueryHasCorrectStart(CREATE_QUERY_START);

        public CreateTableValidator() {
            _middleware 
                .LinkWith(new CreateTableHasValidParameters());
        }

        public bool Validate(string query) {
            return _middleware.Check(query);
        }
    }
}