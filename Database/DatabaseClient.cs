using System;
using JsonDatabase.Exceptions;

namespace JsonDatabase.Database {
    public class DatabaseClient {

        public ResultSet ExecuteQuery(string query) {
            var arguments = query.Split("(");
            if(arguments.Length != 2) throw new GenericException("");

            foreach(var argument in arguments) {
                Console.WriteLine(argument);
            }
            
            return new ResultSet{ isSuccess=true };
        }

        private bool CreateTable(string name, string schema) {
            return true;
        }
    }
}