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
            
            var queryColumnNames = arguments[1].Split(")")[0].Split(",").Select(x => x.Trim());
            var databaseColumnNames = _database.GetTable(tableName).GetColumnNames();

            foreach(var column in queryColumnNames) {
                if(!databaseColumnNames.Contains(column)) throw new UnknownColumnNameException(column);
            }
            
            return this.CheckNext(query);
        }
    }
}