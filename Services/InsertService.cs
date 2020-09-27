using System.Linq;
using PathonDB.Models.Database;
using PathonDB.Models.Table;
using PathonDB.Utils;
using PathonDB.Validators;

namespace PathonDB.Services {
    public class InsertService : Service {
        public InsertService(IDatabase database) : base(database) {}

        public void PerformQuery(string query) {
            new InsertValidator(this._database).Validate(query);
            this.InsertRow(query);
        }

        private void InsertRow(string query) {
            var arguments = InsertUtils.GetArgumentsFromQuery(query.Substring(0, query.Length - 2));
            var tableName = InsertUtils.GetTableNameFromQuery(query);

            var columnNames = InsertUtils.GetColumnsFromArguments(arguments).ToList();
            var values = InsertUtils.GetValuesFromArguments(arguments).Select(x => GeneralUtils.TransformStringValueToRealValue(x)).ToList();

            var record = new Record(columnNames, values);
            this._database.GetTable(tableName).AddRecord(record);
        }
    }
}