using System;
using System.Linq;
using PathonDB.DatabaseClient.Exceptions.General;
using PathonDB.DatabaseClient.Middlewares.General;
using PathonDB.DatabaseClient.Models.Database;
using PathonDB.DatabaseClient.Utils;

namespace PathonDB.DatabaseClient.Middlewares.Insert {
    public class HasValidColumnNames : Middleware {
        private readonly IDatabase _database;

        public HasValidColumnNames(IDatabase database) {
            _database = database;
        }
        
        public override bool Check(string query) {
            var arguments = InsertUtils.GetArgumentsFromQuery(query);
            var tableName = InsertUtils.GetTableNameFromQuery(query);
            
            var queryColumns = InsertUtils.GetColumnsFromArguments(arguments);
            var databaseColumns = _database.GetTable(tableName).GetColumnProperties().Select(x => x.Name).ToArray();

            foreach(var column in queryColumns) {
                if(!databaseColumns.Contains(column)) throw new UnknownColumnNameException(column);
            }
            
            return this.CheckNext(query);
        }
    }
}