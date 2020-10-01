using System;
using PathonDB.Exceptions.General;

namespace PathonDB.Middlewares.General {
    public class HasValidBeginning : Middleware
    {
        private readonly string _beginningString;

        public HasValidBeginning(string beginningString) {
            _beginningString = beginningString;
        }

        public override bool Check(string query) {
            var arguments = query.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var actualBeginning = arguments[0].ToUpper() + " " + arguments[1].ToUpper();

            if(actualBeginning != _beginningString) throw new InvalidQueryBeginningException();
            return this.CheckNext(query);
        }
    }
}