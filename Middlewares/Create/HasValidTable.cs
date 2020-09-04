using System;
using System.Linq;
using System.Text.RegularExpressions;
using JsonDatabase.Exceptions.Create;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Models;
using JsonDatabase.Utils;

namespace JsonDatabase.Middlewares.Create {
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