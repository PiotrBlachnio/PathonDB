using JsonDatabase.Middlewares.General;
using JsonDatabase.Middlewares.Insert;
using JsonDatabase.Models;

namespace JsonDatabase.Validators {
    public class InsertValidator : Validator {
        private const string QUERY_START = "INSERT INTO ";
        private const string QUERY_END = ");";

        public InsertValidator(Database database) {
            this._middleware = new DoesTableExist(QUERY_START, database);

            this._middleware
                .LinkWith(new HasCorrectEnd(QUERY_END))
                .LinkWith(new HasValidArguments())
                .LinkWith(new HasValidParameters());
        }
    }
}

//TODO: Prepare validator to handle query: INSERT INTO users (username, email) VALUES ("Jeff", "Jeff@gmail.com");