using PathonDB.Middlewares.General;
using PathonDB.Middlewares.Insert;
using PathonDB.Models.Database;

namespace PathonDB.Validators {
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