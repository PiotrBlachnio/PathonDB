using System.Linq;
using PathonDB.Exceptions.Insert;
using PathonDB.Middlewares.General;
using PathonDB.Models;
using PathonDB.Utils;

namespace PathonDB.Middlewares.Insert {
    public class HasValidColumnNumber : Middleware {
        private readonly IDatabase _database;

        public HasValidColumnNumber(IDatabase database) {
            _database = database;
        }
        
        public override bool Check(string query) {
            var arguments = InsertUtils.GetArgumentsFromQuery(query);
            var tableName = InsertUtils.GetTableNameFromQuery(query);
            
            var actualColumnNumber = InsertUtils.GetColumnsFromArguments(arguments).Count();
            var expectedColumnNumber = _database.GetTable(tableName).GetColumnProperties().Count();

            if(actualColumnNumber != expectedColumnNumber) throw new InvalidColumnNumberException(actualColumnNumber, expectedColumnNumber);
            
            return this.CheckNext(query);
        }
    }
}