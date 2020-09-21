using PathonDB.Middlewares.General;
using PathonDB.Middlewares.Create;
using PathonDB.Models;

namespace PathonDB.Validators.Create {
    public class CreateValidator : Validator {
        private const string QUERY_END = ");";
        private const string QUERY_START = "CREATE TABLE";

        public CreateValidator(IDatabase database) {
            this._middleware = new HasValidArguments();

            this._middleware
                .LinkWith(new HasValidBeginning(QUERY_START))
                .LinkWith(new HasValidTable(database))
                .LinkWith(new HasValidEnding(QUERY_END))
                .LinkWith(new HasValidColumns())
                .LinkWith(new HasValidColumnTypes());
        }
    }
}