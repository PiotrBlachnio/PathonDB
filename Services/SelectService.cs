using PathonDB.Models;
using PathonDB.Utils;
using PathonDB.Validators;

namespace PathonDB.Services {
    public class SelectService : Service {
        private RowsData _data;

        public SelectService(IDatabase database) : base(database) {}

        public override void PerformQuery(string query) {
            new SelectValidator(this._database).Validate(query);
            this.SelectData(query);
        }

        private void SelectData(string query) {
            var arguments = SelectUtils.GetArgumentsFromQuery(query);
            var tableName = SelectUtils.GetTableNameFromArguments(arguments);
            var columnNames = SelectUtils.GetColumnNamesFromQuery(query);

            if(columnNames.Length == 0) return;
            if(columnNames[0] == "*") _data = _database.GetTable(tableName).GetAllRows();

            return;
        }

        public RowsData GetData() {
            return _data;
        }
    }
}