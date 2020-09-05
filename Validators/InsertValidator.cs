using JsonDatabase.Middlewares.General;
using JsonDatabase.Middlewares.Insert;
using JsonDatabase.Models;

namespace JsonDatabase.Validators {
    public class InsertValidator : Validator {
        private const string QUERY_END = ");";

        public InsertValidator(Database database) {
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