using System;
using JsonDatabase.Validators.Create;

namespace JsonDatabase.Database {
    public class DatabaseClient {

        public ResultSet ExecuteQuery(string query) {
            try {
                new CreateTableValidator().Validate(query);
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }

            return new ResultSet{ isSuccess=true };
        }

        private bool CreateTable(string name, string schema) {
            return true;
        }
    }
}

//? Correct: CREATE TABLE users (id text, username int);
//! Malformed parameters: CREATE TABLE users (id text, username;
//! Incorrect start: CREATE KEY users (id text, username int);