using System.Linq;
using JsonDatabase.Exceptions.Insert;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Models;
using JsonDatabase.Utils;

namespace JsonDatabase.Middlewares.Insert {
    public class HasValidColumnTypes : Middleware {
        private readonly IDatabase _database;

        public HasValidColumnTypes(IDatabase database) {
            _database = database;
        }
        
        public override bool Check(string query) {
            var arguments = InsertUtils.GetArgumentsFromQuery(query);
            var tableName = InsertUtils.GetTableNameFromQuery(query);

            var columns = InsertUtils.GetColumnsFromArguments(arguments).ToArray();
            var values = arguments[2].Split(",").Select(x => x.Trim()).ToArray();

            var columnTypes = _database.GetTable(tableName).GetColumnTypes();
            
            for(var i = 0; i < columns.Count(); i++) {
                if(!GeneralUtils.IsTypeValid(columnTypes[columns[i]], values[i])) throw new InvalidColumnTypeException(columns[i], columnTypes[columns[i]]);
            }
            
            return this.CheckNext(query);
        }
    }
}