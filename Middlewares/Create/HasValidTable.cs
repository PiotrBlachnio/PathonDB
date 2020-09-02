using System;
using System.Linq;
using JsonDatabase.Exceptions.Create;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Models;
using JsonDatabase.Utils;

namespace JsonDatabase.Middlewares.Create {
    public class HasValidTable : Middleware {
        private readonly Database _database;

        public HasValidTable(Database database) {
            _database = database;
        }

        public override bool Check(string query) {
            var tableName = CreateUtils.GetTableNameFromQuery(query);
            if(_database.GetTableNames().Contains(tableName)) throw new TableAlreadyExistsException(tableName);

            return this.CheckNext(query);
        }
    }
}