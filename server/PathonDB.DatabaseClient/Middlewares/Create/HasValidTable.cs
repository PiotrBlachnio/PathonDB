using System;
using System.Linq;
using System.Text.RegularExpressions;
using PathonDB.DatabaseClient.Exceptions.Create;
using PathonDB.DatabaseClient.Middlewares.General;
using PathonDB.DatabaseClient.Models.Database;
using PathonDB.DatabaseClient.Utils;

namespace PathonDB.DatabaseClient.Middlewares.Create {
    public class HasValidTable : Middleware {
        private readonly IDatabase _database;

        public HasValidTable(IDatabase database) {
            _database = database;
        }

        public override bool Check(string query) {
            var tableName = CreateUtils.GetTableNameFromQuery(query);
            
            if(!Regex.IsMatch(tableName, @"^[a-zA-Z]+$")) throw new ForbiddenTableNameException(tableName);
            if(_database.GetTableNames().Contains(tableName)) throw new TableAlreadyExistsException(tableName);

            return this.CheckNext(query);
        }
    }
}