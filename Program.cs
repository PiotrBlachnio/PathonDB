using PathonDB.Models;

namespace PathonDB {
    class Program {
        static void Main(string[] args) {
            var client = new DatabaseClient();
            var queries = new string[] {
                "  CREATE TABLE   users    (  email    text   , phoneNumber int, isAdult boolean);",
                "INSERT INTO   users    (isAdult,  email,  phoneNumber )  VALUES  (true, \"Jeff@gmail.com\", 703503);"
            };

            client.ExecuteQuery(queries); 
        }
    }
}