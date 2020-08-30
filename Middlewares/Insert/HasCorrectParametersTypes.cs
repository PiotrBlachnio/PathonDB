using System.Linq;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Models;

namespace JsonDatabase.Middlewares.Insert {
    public class HasCorrectParametersTypes : Middleware {
        private readonly Database _database;

        public HasCorrectParametersTypes(Database database) {
            _database = database;
        }
        
        public override bool Check(string query) {
            var arguments = query.Split("(");
            var tableName = arguments[0].Trim().ToLower();

            var columnNames = arguments[1].Split(")")[0].Split(",").Select(x => x.Trim()).Select(x => x.Split(" "));
            var values = arguments[2].Split(",").Select(x => x.Trim()).Select(x => x.Split(" "));

            var columnTypes = _database.GetTable(tableName).GetColumnsTypes();
            
            for(var i = 0; i < columnNames.Count(); i++) {
                
            }
            
            return this.CheckNext(query);
        }

        private bool IsTypeCompatible(string type, string value) {
            switch(type.ToLower()) {
                case "text":
                    if(value[0] != '"' || value[value.Length - 1] != '"') 
            }
        }
    }
}