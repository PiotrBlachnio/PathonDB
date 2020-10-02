using PathonDB.DatabaseClient.Middlewares.General;
using PathonDB.DatabaseClient.Middlewares.Create;
using PathonDB.DatabaseClient.Models.Database;

namespace PathonDB.DatabaseClient.Validators.Create {
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