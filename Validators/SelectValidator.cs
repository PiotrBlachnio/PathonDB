using PathonDB.Middlewares.General;
using PathonDB.Middlewares.Select;
using PathonDB.Models;

namespace PathonDB.Validators {
    public class SelectValidator : Validator {
        private const string QUERY_END = ";";

        public SelectValidator(IDatabase database) {
            this._middleware = new HasValidArguments();

            this._middleware
                .LinkWith(new HasValidEnding(QUERY_END))
                .LinkWith(new HasValidTable(database))
                .LinkWith(new HasValidColumns(database))
                .LinkWith(new HasValidCondition(database));
        }
    }
}