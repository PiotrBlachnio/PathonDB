using PathonDB.DatabaseClient.Middlewares.General;
using PathonDB.DatabaseClient.Middlewares.Select;
using PathonDB.DatabaseClient.Models.Database;

namespace PathonDB.DatabaseClient.Validators {
    public class SelectValidator : Validator {
        private const string QUERY_END = ";";

        public SelectValidator(IDatabase database) {
            this._middleware = new HasValidArguments();

            this._middleware
                .LinkWith(new HasValidEnding(QUERY_END))
                .LinkWith(new HasValidTable(database))
                .LinkWith(new HasValidColumns(database))
                .LinkWith(new HasValidCondition())
                .LinkWith(new HasValidConditionColumnName(database))
                .LinkWith(new HasValidConditionValueType(database));
        }
    }
}