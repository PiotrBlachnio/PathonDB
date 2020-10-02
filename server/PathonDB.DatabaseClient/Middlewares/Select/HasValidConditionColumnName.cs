using System.Linq;
using PathonDB.DatabaseClient.Exceptions.General;
using PathonDB.DatabaseClient.Middlewares.General;
using PathonDB.DatabaseClient.Models.Database;
using PathonDB.DatabaseClient.Utils;

namespace PathonDB.DatabaseClient.Middlewares.Select {
    public class HasValidConditionColumnName : Middleware {
        private readonly IDatabase _database;

        public HasValidConditionColumnName(IDatabase database) {
            _database = database; 
        }

        public override bool Check(string query) {
            var arguments = SelectUtils.GetArgumentsFromQuery(query);
            
            var condition = SelectUtils.GetConditionFromQuery(query);
            var tableName = SelectUtils.GetTableNameFromArguments(arguments).ToLower();

            var columnNames = _database.GetTable(tableName).GetColumnProperties().Select(x => x.Name).ToArray();
            if(condition != null && !columnNames.Contains(condition[0])) throw new UnknownColumnNameException(condition[0]);

            return CheckNext(query);
        }
    }
}