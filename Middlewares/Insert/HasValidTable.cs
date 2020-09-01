using System;
using System.Linq;
using JsonDatabase.Exceptions.General;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Models;
using JsonDatabase.Utils;

namespace JsonDatabase.Middlewares.Insert {
    public class HasValidTable : Middleware {
        private readonly Database _database;

        public HasValidTable(Database database) {
            _database = database;
        }

        public override bool Check(string query) {
            var tableName = InsertUtils.GetTableNameFromQuery(query);
            if(!_database.GetTableNames().Contains(tableName)) throw new TableNotFoundException(tableName);

            return this.CheckNext(query);
        }
    }
}