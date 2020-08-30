using System;
using System.Linq;
using JsonDatabase.Exceptions;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Models;

namespace JsonDatabase.Middlewares.Insert {
    public class HasCorrectParametersNames : Middleware {
        private readonly Database _database;

        public HasCorrectParametersNames(Database database) {
            _database = database;
        }
        
        public override bool Check(string query) {
            var arguments = query.Split("(");
            var tableName = arguments[0].Trim().ToLower();
            
            var columnNames = arguments[1].Split(")")[0].Split(",").Select(x => x.Trim());
            
            foreach(var column in _database.GetColumnNames(tableName)) Console.WriteLine(column);
            if(!columnNames.All(x => _database.GetColumnNames(tableName).Contains(x))) throw new IncorrectParametersNumberException(columnNames.Count(), _database.GetColumnNames(tableName).Count());
            
            return this.CheckNext(query);
        }
    }
}