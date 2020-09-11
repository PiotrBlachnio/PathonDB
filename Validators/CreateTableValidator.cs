using PathonDB.Middlewares.General;
using PathonDB.Middlewares.Create;
using PathonDB.Models;

namespace PathonDB.Validators.Create {
    public class CreateTableValidator : Validator {
        private const string QUERY_END = ");";

        public CreateTableValidator(IDatabase database) {
            this._middleware = new HasValidArguments();

            this._middleware
                .LinkWith(new HasValidTable(database))
                .LinkWith(new HasValidEnding(QUERY_END))
                .LinkWith(new HasValidColumns())
                .LinkWith(new HasValidColumnTypes());
        }
    }
}