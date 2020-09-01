using JsonDatabase.Middlewares.General;
using JsonDatabase.Middlewares.Create;
using JsonDatabase.Models;

namespace JsonDatabase.Validators.Create {
    public class CreateTableValidator : Validator {
        private const string QUERY_START = "CREATE TABLE ";
        private const string QUERY_END = ");";

        public CreateTableValidator(Database database) {
            this._middleware = new HasValidTableName(QUERY_START, database);

            this._middleware
                .LinkWith(new HasCorrectEnd(QUERY_END))
                .LinkWith(new HasValidColumns())
                .LinkWith(new HasValidColumnTypes());
        }
    }
}