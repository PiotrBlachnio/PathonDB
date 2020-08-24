using System;

namespace JsonDatabase.Database {
    public class DatabaseClient {
        public bool ExecuteQuery(string query) {
            var arguments = query.Split(" ");
            
            foreach(var argument in arguments) {
                Console.WriteLine(argument);
            }

            return true;
        }
    }
}