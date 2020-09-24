using System.Linq;
using PathonDB.Exceptions.General;
using PathonDB.Middlewares.General;
using PathonDB.Models;
using PathonDB.Utils;

namespace PathonDB.Middlewares.Select {
    public class HasValidConditionColumnName : Middleware {
        private readonly IDatabase _database;

        public HasValidConditionColumnName(IDatabase database) {
            _database = database; 
        }

        public override bool Check(string query) {
            var arguments = SelectUtils.GetArgumentsFromQuery(query);
            
            var condition = SelectUtils.GetConditionFromQuery(query);
            var tableName = SelectUtils.GetTableNameFromArguments(arguments).ToLower();

            var columnNames = _database.GetTable(tableName).GetColumnNames();
            if(!columnNames.Contains(condition[0])) throw new UnknownColumnNameException(condition[0]);

            return CheckNext(query);
        }
    }
}