using System.Linq;
using PathonDB.DatabaseClient.Exceptions.General;
using PathonDB.DatabaseClient.Middlewares.General;
using PathonDB.DatabaseClient.Models.Database;
using PathonDB.DatabaseClient.Utils;

namespace PathonDB.DatabaseClient.Middlewares.Select {
    public class HasValidColumns : Middleware {
        private readonly IDatabase _database;

        public HasValidColumns(IDatabase database) {
            _database = database;
        }

        public override bool Check(string query) {
            var queryColumnNames = SelectUtils.GetColumnNamesFromQuery(query);
            if(queryColumnNames.Length == 0 || queryColumnNames[0] == "*") return CheckNext(query);

            var tableName = SelectUtils.GetTableNameFromArguments(SelectUtils.GetArgumentsFromQuery(query)).ToLower();
            var databaseColumnNames = _database.GetTable(tableName).GetColumnProperties().Select(x => x.Name).ToArray();

            foreach(var columnName in (string[]) queryColumnNames) {
                if(!databaseColumnNames.Contains(columnName) && columnName.ToLower() != "id") throw new UnknownColumnNameException(columnName);
            }
            
            return CheckNext(query);
        }
    }
}