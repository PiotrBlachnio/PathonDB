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

//? Correct: CREATE TABLE users (email text, phoneNumber int);
//! Incorrect query argument: GET * FROM users;
//! Incorrect start: CREATE KEY users (email text, phoneNumber int);
//! Incorrect table name: CREATE TABLE (email text, phoneNumber int);
//! Incorrect end: CREATE TABLE users (email text, phoneNumber int)
//! Malformed parameters: CREATE TABLE users (email text, phoneNumber int);
//! Unsupported types: CREATE TABLE users (email text, phoneNumber bigint);
//! Forbidden column name: CREATE TABLE users (id text, email text);