using System.Linq;
using JsonDatabase.Exceptions;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Models;

namespace JsonDatabase.Middlewares.Insert {
    public class HasCorrectParametersNumber : Middleware {
        private readonly Database _database;

        public HasCorrectParametersNumber(Database database) {
            _database = database;
        }
        
        public override bool Check(string query) {
            var arguments = query.Split("(");
            var tableName = arguments[0].Trim().ToLower();
            
            var queryColumnsNumber = arguments[1].Split(")")[0].Split(",").Select(x => x.Trim()).Select(x => x.Split(" ")).Count();
            var databaseColumnsNumber = _database.GetTable(tableName).GetColumnNames().Count();

            if(databaseColumnsNumber != queryColumnsNumber) throw new IncorrectParametersNumberException(queryColumnsNumber, databaseColumnsNumber);
            
            return this.CheckNext(query);
        }
    }
}