using System;
using System.Linq;
using JsonDatabase.Exceptions;

namespace JsonDatabase.Database {
    public class DatabaseClient {

        public ResultSet ExecuteQuery(string query) {
            var arguments = query.Split("(");
            if(arguments.Length != 2) throw new MalformedParametersException();

            if(!(arguments[1].Split(",").Select(x => x.Trim()).Select(x => x.Split(" ")).All(x => x.Length == 2))) throw new MalformedParametersException();

            // foreach(var argument in parameters) {
            //     Console.WriteLine(argument);
            // }
            
            return new ResultSet{ isSuccess=true };
        }

        private bool CreateTable(string name, string schema) {
            return true;
        }
    }
}

// CREATE TABLE users (id text, username int);