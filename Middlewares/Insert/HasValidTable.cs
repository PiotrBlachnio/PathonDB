using System;
using System.Linq;
using JsonDatabase.Exceptions.General;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Models;

namespace JsonDatabase.Middlewares.Insert {
    public class HasValidTable : Middleware {
        private readonly Database _database;
        private readonly string _startingString;

        public HasValidTable(string startingString, Database database) {
            _startingString = startingString;
            _database = database;
        }

        public override bool Check(string query) {
            var substring = query.Substring(_startingString.Length);
            var splittedSubstring = substring.Split(" ");

            var tableName = splittedSubstring[0].ToLower().Trim();
            if(!_database.GetTableNames().Contains(tableName)) throw new TableNotFoundException(tableName);

            return this.CheckNext(substring);
        }
    }
}