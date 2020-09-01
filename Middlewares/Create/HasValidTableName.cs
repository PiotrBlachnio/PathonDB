using System;
using System.Linq;
using JsonDatabase.Exceptions.Create;
using JsonDatabase.Exceptions.General;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Models;
using JsonDatabase.Utils;

namespace JsonDatabase.Middlewares.Create {
    public class HasValidTableName : Middleware {
        private readonly Database _database;
        private readonly string _startingString;

        public HasValidTableName(string startingString, Database database) {
            _startingString = startingString;
            _database = database;
        }

        public override bool Check(string query) {
            var substring = query.Substring(_startingString.Length);
            string[] arguments = CreateUtils.GetArgumentsFromQuery(query);

            if(arguments.Length < 2 || substring.StartsWith("(") || arguments[0].Equals("")) throw new TableNotFoundException(arguments[0]);
            
            var tableName = CreateUtils.GetTableNameFromQuery(query);
            if(_database.GetTableNames().Contains(tableName)) throw new TableAlreadyExistsException(tableName);

            return this.CheckNext(query);
        }
    }
}