using JsonDatabase.Middlewares.General;
using JsonDatabase.Middlewares.Create;
using System.Collections.Generic;

namespace JsonDatabase.Validators.Create {
    public class CreateTableValidator : Validator {
        private const string CREATE_QUERY_START = "CREATE TABLE ";
        private const string CREATE_QUERY_END = ");";

        public CreateTableValidator(Dictionary<string, dynamic> storage) {
            this._middleware =
                new QueryHasCorrectStart(CREATE_QUERY_START)
                .LinkWith(new CreateTableHasValidParameters());
        }
    }
}