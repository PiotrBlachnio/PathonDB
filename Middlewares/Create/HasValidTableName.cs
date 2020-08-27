using System.Linq;
using JsonDatabase.Exceptions;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Models;

namespace JsonDatabase.Middlewares.Create {
    public class HasValidTableName : Middleware {
        private readonly Database _database;
        private readonly string _startingString;

        public HasValidTableName(string startingString, Database database) {
            _startingString = startingString;
            _database = database;
        }

        public override bool Check(string query) {
            var substring = query.Substring(_startingString.Length);
            string[] arguments = substring.Trim().Split("(");

            if(arguments.Length < 2 || substring.StartsWith("(") || arguments[0].Equals("")) throw new InvalidTableNameException(arguments[0]);
            if(_database.GetTableNames().Contains(arguments[0].ToLower())) throw new TableAlreadyExistsException(arguments[0].ToLower());

            return this.CheckNext(query);
        }
    }
}