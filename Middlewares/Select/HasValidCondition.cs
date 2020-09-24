using System.Linq;
using PathonDB.Exceptions.General;
using PathonDB.Middlewares.General;
using PathonDB.Models;
using PathonDB.Utils;

namespace PathonDB.Middlewares.Select {
    public class HasValidCondition : Middleware {
        private readonly IDatabase _database;

        public HasValidCondition(IDatabase database) {
            _database = database; 
        }

        public override bool Check(string query) {
            var arguments = SelectUtils.GetArgumentsFromQuery(query);
            var keyword = SelectUtils.GetWhereKeywordFromArguments(arguments);
            
            var condition = SelectUtils.GetConditionFromQuery(query);
            var tableName = SelectUtils.GetTableNameFromArguments(arguments).ToLower();

            if(keyword != null && condition == null) throw new MalformedArgumentsException();

            var columnNames = _database.GetTable(tableName).GetColumnNames();
            if(!columnNames.Contains(condition[0])) throw new UnknownColumnNameException(condition[0]);

            var columnTypes = _database.GetTable(tableName).GetColumnTypes();
            if(!GeneralUtils.IsTypeValid(columnTypes[condition[0]], condition[1])) throw new InvalidColumnTypeException(condition[0], columnTypes[condition[0]]);

            return CheckNext(query);
        }
    }
}