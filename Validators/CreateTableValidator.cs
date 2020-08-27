using JsonDatabase.Middlewares.General;
using JsonDatabase.Middlewares.Create;
using JsonDatabase.Models;

namespace JsonDatabase.Validators.Create {
    public class CreateTableValidator : Validator {
        private const string QUERY_START = "CREATE TABLE ";
        private const string QUERY_END = ");";

        public CreateTableValidator(Database database) {
            this._middleware = new QueryHasCorrectStart(QUERY_START);

            this._middleware
                .LinkWith(new HasValidTableName(database))
                .LinkWith(new QueryHasCorrectEnd(QUERY_END))
                .LinkWith(new HasValidParameters())
                .LinkWith(new HasValidSupportedTypes());
        }
    }
}