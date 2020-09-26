using System.Linq;
using PathonDB.Exceptions.General;
using PathonDB.Middlewares.General;
using PathonDB.Models.Database;
using PathonDB.Utils;

namespace PathonDB.Middlewares.Select {
    public class HasValidTable : Middleware {
        private readonly IDatabase _database;

        public HasValidTable(IDatabase database) {
            _database = database;
        }

        public override bool Check(string query) {
            var tableName = SelectUtils.GetTableNameFromArguments(SelectUtils.GetArgumentsFromQuery(query)).ToLower();
            if(!_database.GetTableNames().Contains(tableName)) throw new TableNotFoundException(tableName);

            return this.CheckNext(query);
        }
    }
}