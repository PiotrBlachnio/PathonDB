using PathonDB.Models.Database;
using PathonDB.Models.Table;
using PathonDB.Utils;
using PathonDB.Validators;

namespace PathonDB.Services {
    public class SelectService : Service {
        private Record[] _records = null;

        public SelectService(IDatabase database) : base(database) {}

        public override void PerformQuery(string query) {
            new SelectValidator(this._database).Validate(query);
            this.SelectData(query);
        }

        private void SelectData(string query) {
            var arguments = SelectUtils.GetArgumentsFromQuery(query);
            var tableName = SelectUtils.GetTableNameFromArguments(arguments).ToLower().TrimEnd(';');
            var columnNames = SelectUtils.GetColumnNamesFromQuery(query);

            if(columnNames.Length == 0) return;
            if(columnNames[0] == "*") columnNames = null;

            var condition = SelectUtils.GetConditionFromQuery(query);

            if(condition == null) {
               _records = _database.GetTable(tableName).GetRecords(columnNames, null);
            } else {
                _records = _database.GetTable(tableName).GetRecords(columnNames, new Condition(condition[0], condition[1]));
            }

            return;
        }

        public Record[] GetRecords() {
            return _records;
        }
    }
}