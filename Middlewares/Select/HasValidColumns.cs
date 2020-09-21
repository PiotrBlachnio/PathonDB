using PathonDB.Middlewares.General;
using PathonDB.Models;
using PathonDB.Utils;

namespace PathonDB.Middlewares.Select {
    public class HasValidColumns : Middleware {
        private readonly IDatabase _database;

        public HasValidColumns(IDatabase database) {
            _database = database;
        }

        public override bool Check(string query) {
            var queryColumnNames = SelectUtils.GetColumnNamesFromQuery(query);

            return CheckNext(query);
        }
    }
}