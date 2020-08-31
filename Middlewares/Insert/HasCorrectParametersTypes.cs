using System.Linq;
using JsonDatabase.Exceptions;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Models;

namespace JsonDatabase.Middlewares.Insert {
    public class HasValidColumnTypes : Middleware {
        private readonly Database _database;

        public HasValidColumnTypes(Database database) {
            _database = database;
        }
        
        public override bool Check(string query) {
            var arguments = query.Split("(");
            var tableName = arguments[0].Trim().ToLower();

            var columnNames = arguments[1].Split(")")[0].Split(",").Select(x => x.Trim()).ToArray();
            var values = arguments[2].Split(",").Select(x => x.Trim()).ToArray();

            var columnTypes = _database.GetTable(tableName).GetColumnTypes();
            
            for(var i = 0; i < columnNames.Count(); i++) {
                if(!IsTypeCompatible(columnTypes[columnNames[i]], values[i])) throw new InvalidColumnTypeException(columnNames[i], columnTypes[columnNames[i]]);
            }
            
            return this.CheckNext(query);
        }

        private bool IsTypeCompatible(string type, string value) {
            switch(type.ToLower()) {
                case "text":
                    if(value[0] != '"' || value[value.Length - 1] != '"') return false;
                    break;
                case "int":
                    if(!int.TryParse(value, out int i)) return false;
                    break;
                case "boolean":
                    if(value != "true" && value != "false") return false;
                    break;
            }

            return true;
        }
    }
}