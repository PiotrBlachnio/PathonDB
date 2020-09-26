using System;
using Newtonsoft.Json;
using PathonDB.Exceptions.General;
using PathonDB.Services;

namespace PathonDB.Models {
    public class DatabaseClient {
        private readonly IDatabase _database = new Database();

        public void ExecuteQuery(string[] queries) {
            foreach(var q in queries) {
                var query = q.TrimStart();
                var arguments = query.Split(" ");

                switch(arguments[0].ToUpper()) {
                    case "CREATE":
                        new CreateService(_database).PerformQuery(query);
                        break;
                    case "INSERT":
                        new InsertService(_database).PerformQuery(query);
                        break;
                    case "SELECT":
                        var service = new SelectService(_database);
                        service.PerformQuery(query);

                        Console.WriteLine(JsonConvert.SerializeObject(service.GetRecords(), Formatting.Indented));
                        break;
                    default:
                        throw new MalformedArgumentsException();
                }
            }
        }
    }
}

//? Correct: CREATE TABLE users (email text, phoneNumber int);
//! Incorrect query arguments: GET * FROM users;
//! Incorrect start: CREATE KEY users (email text, phoneNumber int);
//! Incorrect table name: CREATE TABLE (email text, phoneNumber int);
//! Incorrect end: CREATE TABLE users (email text, phoneNumber int)
//! Malformed parameters: CREATE TABLE users (email, phoneNumber int);
//! Unsupported types: CREATE TABLE users (email text, phoneNumber bigint);
//! Forbidden column name: CREATE TABLE users (id text, email text);

//? Correct: INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);
//! Incorrect argument: INSERT INTO users (email, phoneNumber) VALUE (\"Jeff@gmail.com\", 703503);
//! Incorrect parameters: INSERT INTO users (email phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);
//! Incorrect parameters case 2: INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\");
//! Incorrect parameters number: INSERT INTO users (email) VALUES (\"Jeff@gmail.com\");
//! Incorrect parameters names: INSERT INTO users (email, phoneNumberr) VALUES (\"Jeff@gmail.com\", 703503);
//! Incorrect parameter types: INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", true);

//? Correct: SELECT * FROM users;