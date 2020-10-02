using PathonDB.Models.Database;
using PathonDB.Models.Table;
using PathonDB.Utils;
using PathonDB.Validators;

namespace PathonDB.Services {
    public class SelectService : Service {
        public SelectService(IDatabase database) : base(database) {}

        public Record[] PerformQuery(string query) {
            new SelectValidator(this._database).Validate(query);
            return this.SelectData(query);
        }

        private Record[] SelectData(string query) {
            var arguments = SelectUtils.GetArgumentsFromQuery(query);
            var tableName = SelectUtils.GetTableNameFromArguments(arguments).ToLower().TrimEnd(';');
            var columnNames = SelectUtils.GetColumnNamesFromQuery(query);

            if(columnNames.Length == 0) return null;
            if(columnNames[0] == "*") columnNames = null;

            var condition = SelectUtils.GetConditionFromQuery(query);

            return _database.GetTable(tableName).GetRecords(columnNames, condition == null ? null : new Condition(condition[0], condition[1]));
        }
    }
}