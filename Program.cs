using System;
using JsonDatabase.Models;

namespace JsonDatabase {
    class Program {
        static void Main(string[] args) {
            var client = new DatabaseClient();
            var queries = new string[] {
                "CREATE TABLE    users  (email text, phoneNumber int, isAdult boolean);",
                "INSERT INTO users (isAdult, email, phoneNumber) VALUES (true, \"Jeff@gmail.com\", 703503);"
            };

            client.ExecuteQuery(queries);
            // while(true) {
                // Console.WriteLine("Enter you query:");
                // var query = Console.ReadLine();

                // try {
                // client.ExecuteQuery(query);
                // } catch(Exception ex) {
                //     Console.ForegroundColor = ConsoleColor.Red;
                //     Console.WriteLine(ex.Message);
                //     Console.ResetColor();
                // }   
            // }    
        }
    }
}