using System;
using JsonDatabase.Validators.Create;

namespace JsonDatabase.Database {
    public class DatabaseClient {

        public ResultSet ExecuteQuery(string query) {
            Console.WriteLine(new CreateTableValidator().Validate(query));
            return new ResultSet{ isSuccess=true };
        }

        private bool CreateTable(string name, string schema) {
            return true;
        }
    }
}

// CREATE TABLE users (id text, username int);