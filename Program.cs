using System;
using JsonDatabase.Models;

namespace JsonDatabase {
    class Program {
        static void Main(string[] args) {
            var client = new DatabaseClient();
            Console.WriteLine("Enter you query:");
            var query = Console.ReadLine();

            try {
                client.ExecuteQuery(query);
            } catch(Exception ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }          
        }
    }
}