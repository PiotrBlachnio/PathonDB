using System.Collections.Generic;
using System.Linq;
using JsonDatabase.Exceptions;
using JsonDatabase.Services;

namespace JsonDatabase.Database {
    public class DatabaseClient {
        private readonly Dictionary<string, dynamic> _storage = new Dictionary<string, dynamic>();

        public ResultSet ExecuteQuery(string query) {
            var arguments = query.Split(" ");

            switch(arguments[0].ToUpper()) {
                case "CREATE":
                    new CreateService(_storage).PerformQuery(query);
                    break;
                default:
                    throw new InvalidQueryArgumentsException(arguments[0]);
            }
            
            return new ResultSet{ isSuccess=true };
        }

        public string[] GetTableNames() {
            return this._storage.Keys.ToArray();
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