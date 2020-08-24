using System;
using JsonDatabase.Database;

namespace JsonDatabase {
    class Program {
        static void Main(string[] args) {
            var client = new DatabaseClient();
            
            Console.WriteLine("Enter you query:");
            var query = Console.ReadLine();
            client.ExecuteQuery(query);
        }
    }
}