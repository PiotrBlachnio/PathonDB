using System.Linq;
using PathonDB.Exceptions.General;
using PathonDB.Middlewares.General;
using PathonDB.Models;
using PathonDB.Utils;

namespace PathonDB.Middlewares.Select {
    public class HasValidColumns : Middleware {
        private readonly IDatabase _database;

        public HasValidColumns(IDatabase database) {
            _database = database;
        }

        public override bool Check(string query) {
            var queryColumnNames = SelectUtils.GetColumnNamesFromQuery(query);
            if(queryColumnNames.Length == 0 || queryColumnNames[0] == "*") return CheckNext(query);

            var databaseColumnNames = _database.GetTable(SelectUtils.GetTableNameFromArguments(SelectUtils.GetArgumentsFromQuery(query))).GetColumnNames();

            foreach(var columnName in (string[]) queryColumnNames) {
                if(!databaseColumnNames.Contains(columnName) && columnName.ToLower() != "id") throw new UnknownColumnNameException(columnName);
            }
            
            return CheckNext(query);
        }
    }
}