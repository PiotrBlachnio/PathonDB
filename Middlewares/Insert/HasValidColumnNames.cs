using System;
using System.Linq;
using PathonDB.Exceptions.General;
using PathonDB.Middlewares.General;
using PathonDB.Models;
using PathonDB.Utils;

namespace PathonDB.Middlewares.Insert {
    public class HasValidColumnNames : Middleware {
        private readonly IDatabase _database;

        public HasValidColumnNames(IDatabase database) {
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