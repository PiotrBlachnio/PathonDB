using PathonDB.Exceptions.General;
using PathonDB.Middlewares.General;
using PathonDB.Models;
using PathonDB.Utils;

namespace PathonDB.Middlewares.Select {
    public class HasValidConditionValueType : Middleware {
        private readonly IDatabase _database;

        public HasValidConditionValueType(IDatabase database) {
            _database = database; 
        }

        public override bool Check(string query) {
            var arguments = SelectUtils.GetArgumentsFromQuery(query);
            
            var condition = SelectUtils.GetConditionFromQuery(query);
            var tableName = SelectUtils.GetTableNameFromArguments(arguments).ToLower();

            var columnTypes = _database.GetTable(tableName).GetColumnTypes();
            if(!GeneralUtils.IsTypeValid(columnTypes[condition[0]], condition[1])) throw new InvalidColumnTypeException(condition[0], columnTypes[condition[0]]);
            
            return CheckNext(query);
        }
    }
}