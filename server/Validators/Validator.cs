using PathonDB.Middlewares.General;

namespace PathonDB.Validators {
    public abstract class Validator {
        protected Middleware _middleware;

        public bool Validate(string query) {
            return _middleware.Check(query);
        }
    }
}