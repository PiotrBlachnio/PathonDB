using System;
using JsonDatabase.Database;

namespace JsonDatabase {
    class Program {
        static void Main(string[] args) {
            try {
                var client = new DatabaseClient();
            
                Console.WriteLine("Enter you query:");
                var query = Console.ReadLine();
                client.ExecuteQuery(query);
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }  
        }
    }
}