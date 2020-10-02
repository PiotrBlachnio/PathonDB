using PathonDB.DatabaseClient.Middlewares.General;

namespace PathonDB.DatabaseClient.Validators {
    public abstract class Validator {
        protected Middleware _middleware;

        public bool Validate(string query) {
            return _middleware.Check(query);
        }
    }
}