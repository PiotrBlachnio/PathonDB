using System.Collections.Generic;
using System.Linq;
using JsonDatabase.Exceptions;
using JsonDatabase.Validators.Create;

namespace JsonDatabase.Database {
    public class DatabaseClient {
        private readonly Dictionary<string, dynamic> _storage = new Dictionary<string, dynamic>();

        public ResultSet ExecuteQuery(string query) {
            ValidateQuery(query);
            
            return new ResultSet{ isSuccess=true };
        }

        public string[] GetTableNames() {
            return this._storage.Keys.ToArray();
        }

        private void ValidateQuery(string query) {
            var arguments = query.Split(" ");

            switch(arguments[0].ToUpper()) {
                case "CREATE":
                    new CreateTableValidator(_storage).Validate(query);
                    break;
                default:
                    throw new InvalidQueryTypeException(arguments[0]);
            }
        }
    }
}

//? Correct: CREATE TABLE users (id text, username int);
//! Incorrect query type: GET * FROM users;
//! Incorrect start: CREATE KEY users (id text, username int);
//! Incorrect table name: CREATE TABLE (id text, username int);
//! Incorrect end: CREATE TABLE users (id text, username int)
//! Malformed parameters: CREATE TABLE users (id text, username);
//! Unsupported types: CREATE TABLE users (id text, username bigint);