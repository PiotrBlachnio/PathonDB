using System.Collections.Generic;
using JsonDatabase.Middlewares.General;

namespace JsonDatabase.Validators {
    public abstract class Validator {
        protected Middleware _middleware = null;

        public bool Validate(string query) {
            return _middleware.Check(query);
        }
    }
}