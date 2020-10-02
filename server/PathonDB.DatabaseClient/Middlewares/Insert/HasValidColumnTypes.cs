using System.Linq;
using PathonDB.DatabaseClient.Exceptions.General;
using PathonDB.DatabaseClient.Middlewares.General;
using PathonDB.DatabaseClient.Models.Database;
using PathonDB.DatabaseClient.Utils;

namespace PathonDB.DatabaseClient.Middlewares.Insert {
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

            var columnProperties = _database.GetTable(tableName).GetColumnProperties();
            
            for(var i = 0; i < columns.Count(); i++) {
                if(GeneralUtils.ContainsForbiddenCharacters(values[i])) throw new ForbiddenCharactersException(values[i]);

                var type = columnProperties.First(x => x.Name == columns[i]).Type;
                if(!GeneralUtils.IsTypeValid(type, values[i])) throw new InvalidColumnTypeException(columns[i], type);
            }
            
            return this.CheckNext(query);
        }
    }
}