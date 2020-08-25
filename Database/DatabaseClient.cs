using System.Collections.Generic;
using System.Linq;
using JsonDatabase.Validators.Create;

namespace JsonDatabase.Database {
    public class DatabaseClient {
        private readonly Dictionary<string, dynamic> _storage = new Dictionary<string, dynamic>();

        public ResultSet ExecuteQuery(string query) {
            new CreateTableValidator(_storage).Validate(query);

            return new ResultSet{ isSuccess=true };
        }

        public string[] GetTableNames() {
            return this._storage.Keys.ToArray();
        }
    }
}

//? Correct: CREATE TABLE users (id text, username int);
//! Incorrect start: CREATE KEY users (id text, username int);
//! Incorrect table name: CREATE TABLE (id text, username int);
//! Incorrect end: CREATE TABLE users (id text, username int)
//! Malformed parameters: CREATE TABLE users (id text, username);