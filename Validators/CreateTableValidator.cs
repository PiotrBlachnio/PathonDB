using JsonDatabase.Middlewares.General;
using JsonDatabase.Middlewares.Create;
using System.Collections.Generic;

namespace JsonDatabase.Validators.Create {
    public class CreateTableValidator : Validator {
        private const string QUERY_START = "CREATE TABLE ";
        private const string QUERY_END = ");";

        public CreateTableValidator(Dictionary<string, dynamic> storage) {
            this._middleware = new QueryHasCorrectStart(QUERY_START);

            this._middleware
                .LinkWith(new HasValidTableName(storage))
                .LinkWith(new QueryHasCorrectEnd(QUERY_END))
                .LinkWith(new HasValidParameters());
        }
    }
}