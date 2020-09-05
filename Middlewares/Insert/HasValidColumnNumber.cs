using System.Linq;
using JsonDatabase.Exceptions.Insert;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Models;
using JsonDatabase.Utils;

namespace JsonDatabase.Middlewares.Insert {
    public class HasValidColumnNumber : Middleware {
        private readonly IDatabase _database;

        public HasValidColumnNumber(IDatabase database) {
            _database = database;
        }
        
        public override bool Check(string query) {
            var arguments = InsertUtils.GetArgumentsFromQuery(query);
            var tableName = InsertUtils.GetTableNameFromQuery(query);
            
            var actualColumnNumber = InsertUtils.GetColumnsFromArguments(arguments).Count();
            var expectedColumnNumber = _database.GetTable(tableName).GetColumnNames().Count();

            if(actualColumnNumber != expectedColumnNumber) throw new InvalidColumnNumberException(actualColumnNumber, expectedColumnNumber);
            
            return this.CheckNext(query);
        }
    }
}