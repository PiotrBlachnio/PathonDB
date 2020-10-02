using PathonDB.DatabaseClient.Middlewares.General;
using PathonDB.DatabaseClient.Middlewares.Insert;
using PathonDB.DatabaseClient.Models.Database;

namespace PathonDB.DatabaseClient.Validators {
    public class InsertValidator : Validator {
        private const string QUERY_END = ");";
        private const string QUERY_START = "INSERT INTO";

        public InsertValidator(IDatabase database) {
            this._middleware = new HasValidArguments();

            this._middleware
                .LinkWith(new HasValidBeginning(QUERY_START))
                .LinkWith(new HasValidEnding(QUERY_END))
                .LinkWith(new HasValidTable(database))
                .LinkWith(new HasValidColumns())
                .LinkWith(new HasValidColumnNumber(database))
                .LinkWith(new HasValidColumnNames(database))
                .LinkWith(new HasValidColumnTypes(database));
        }
    }
}