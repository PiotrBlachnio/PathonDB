using PathonDB.Middlewares.General;
using PathonDB.Middlewares.Insert;
using PathonDB.Models;

namespace PathonDB.Validators {
    public class InsertValidator : Validator {
        private const string QUERY_END = ");";

        public InsertValidator(IDatabase database) {
            this._middleware = new HasValidArguments();

            this._middleware
                .LinkWith(new HasValidEnding(QUERY_END))
                .LinkWith(new HasValidTable(database))
                .LinkWith(new HasValidColumns())
                .LinkWith(new HasValidColumnNumber(database))
                .LinkWith(new HasValidColumnNames(database))
                .LinkWith(new HasValidColumnTypes(database));
        }
    }
}