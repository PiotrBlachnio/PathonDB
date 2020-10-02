using System.Linq;
using PathonDB.DatabaseClient.Exceptions.Insert;
using PathonDB.DatabaseClient.Middlewares.General;
using PathonDB.DatabaseClient.Models.Database;
using PathonDB.DatabaseClient.Utils;

namespace PathonDB.DatabaseClient.Middlewares.Insert {
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