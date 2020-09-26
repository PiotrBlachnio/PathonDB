using PathonDB.Models;

namespace PathonDB {
    class Program {
        static void Main(string[] args) {
            var client = new DatabaseClient();
            var queries = new string[] {
                "  CREATE   TABLE   users    (  email   text   , phoneNumber int, isAdult boolean);",
                "INSERT    INTO   users    (isAdult,  email,  phoneNumber )  VALUES  (false, \"Jeff@gmail.com\", 703503);",
                "INSERT    INTO   users    (isAdult,  email,  phoneNumber )  VALUES  (false, \"Arnold@gmail.com\", 141505);",
                "SELECT (isAdult) FROM  userS;"
            };

            client.ExecuteQuery(queries); 
        }
    }
}