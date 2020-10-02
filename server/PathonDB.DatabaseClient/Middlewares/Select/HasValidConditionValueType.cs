using System.Linq;
using PathonDB.DatabaseClient.Exceptions.General;
using PathonDB.DatabaseClient.Middlewares.General;
using PathonDB.DatabaseClient.Models.Database;
using PathonDB.DatabaseClient.Utils;

namespace PathonDB.DatabaseClient.Middlewares.Select {
    public class HasValidConditionValueType : Middleware {
        private readonly IDatabase _database;

        public HasValidConditionValueType(IDatabase database) {
            _database = database; 
        }

        public override bool Check(string query) {
            var arguments = SelectUtils.GetArgumentsFromQuery(query);
            
            var condition = SelectUtils.GetConditionFromQuery(query);
            if(condition == null) return CheckNext(query);
            
            var tableName = SelectUtils.GetTableNameFromArguments(arguments).ToLower();

            var columnTypes = _database.GetTable(tableName).GetColumnProperties();
            var type = columnTypes.First(x => x.Name == condition[0]).Type;

            if(!GeneralUtils.IsTypeValid(type, condition[1])) throw new InvalidColumnTypeException(condition[0], type);
            
            return CheckNext(query);
        }
    }
}