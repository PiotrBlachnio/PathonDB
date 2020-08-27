using JsonDatabase.Exceptions;
using JsonDatabase.Services;

namespace JsonDatabase.Models {
    public class DatabaseClient {
        private readonly Database _database = new Database();

        public void ExecuteQuery(string query) {
            var arguments = query.Split(" ");

            switch(arguments[0].ToUpper()) {
                case "CREATE":
                    new CreateService(_database).PerformQuery(query);
                    break;
                default:
                    throw new InvalidQueryArgumentsException(arguments[0]);
            }
        }
    }
}

//? Correct: CREATE TABLE users (id text, username int);
//! Incorrect query argument: GET * FROM users;
//! Incorrect start: CREATE KEY users (id text, username int);
//! Incorrect table name: CREATE TABLE (id text, username int);
//! Incorrect end: CREATE TABLE users (id text, username int)
//! Malformed parameters: CREATE TABLE users (id text, username);
//! Unsupported types: CREATE TABLE users (id text, username bigint);