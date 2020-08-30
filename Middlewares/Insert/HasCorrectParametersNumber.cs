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
            
            var columnNames = arguments[1].Split(")")[0].Split(",").Select(x => x.Trim()).Select(x => x.Split(" "));
            if(_database.GetColumnNames(tableName).Count() != columnNames.Count()) throw new IncorrectParametersNumberException(columnNames.Count(), _database.GetColumnNames(tableName).Count());
            
            return this.CheckNext(query);
        }
    }
}