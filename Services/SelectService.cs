using PathonDB.Models;
using PathonDB.Models.Table;
using PathonDB.Utils;
using PathonDB.Validators;

namespace PathonDB.Services {
    public class SelectService : Service {
        private RowsData _data = new RowsData();

        public SelectService(IDatabase database) : base(database) {}

        public override void PerformQuery(string query) {
            new SelectValidator(this._database).Validate(query);
            this.SelectData(query);
        }

        private void SelectData(string query) {
            var arguments = SelectUtils.GetArgumentsFromQuery(query);
            var tableName = SelectUtils.GetTableNameFromArguments(arguments).ToLower().TrimEnd(';');
            var columnNames = SelectUtils.GetColumnNamesFromQuery(query);
            Record[] records = null;

            if(columnNames.Length == 0) return;
            if(columnNames[0] == "*") columnNames = null;

            var condition = SelectUtils.GetConditionFromQuery(query);

            if(condition == null) {
                _data = _database.GetTable(tableName).GetRowsData(columnNames);
               records = _database.GetTable(tableName).GetRecords(columnNames, null);
            } else {
                _data = _database.GetTable(tableName).GetRowsDataWithCondition(condition, columnNames);
                records = _database.GetTable(tableName).GetRecords(columnNames, new Condition(condition[0], condition[1]));
            }

            return;
        }

        public RowsData GetData() {
            return _data;
        }
    }
}