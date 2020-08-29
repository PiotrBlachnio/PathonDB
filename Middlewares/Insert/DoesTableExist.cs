using System;
using System.Linq;
using JsonDatabase.Exceptions;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Models;

namespace JsonDatabase.Middlewares.Insert {
    public class DoesTableExist : Middleware {
        private readonly Database _database;
        private readonly string _startingString;

        public DoesTableExist(string startingString, Database database) {
            _startingString = startingString;
            _database = database;
        }

        public override bool Check(string query) {
            var substring = query.Substring(_startingString.Length);
            var splittedSubstring = substring.Split(" ");

            var tableName = splittedSubstring[0];
            var valuesKeyword = splittedSubstring[1];

            if(!_database.GetTableNames().Contains(tableName)) throw new TableNotFoundException(tableName);
            if(valuesKeyword.ToUpper() != "VALUES") throw new InvalidQueryArgumentsException(valuesKeyword);

            return this.CheckNext(substring);
        }
    }
}