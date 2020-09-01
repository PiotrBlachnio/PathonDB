using System;
using System.Linq;
using JsonDatabase.Exceptions;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Models;
using JsonDatabase.Utils;

namespace JsonDatabase.Middlewares.Insert {
    public class HasValidColumnNames : Middleware {
        private readonly Database _database;

        public HasValidColumnNames(Database database) {
            _database = database;
        }
        
        public override bool Check(string query) {
            var arguments = InsertUtils.GetArgumentsFromQuery(query);
            var tableName = InsertUtils.GetTableNameFromQuery(query);
            
            var queryColumns = InsertUtils.GetColumnsFromArguments(arguments);
            var databaseColumns = _database.GetTable(tableName).GetColumnNames();

            foreach(var column in queryColumns) {
                if(!databaseColumns.Contains(column)) throw new UnknownColumnNameException(column);
            }
            
            return this.CheckNext(query);
        }
    }
}