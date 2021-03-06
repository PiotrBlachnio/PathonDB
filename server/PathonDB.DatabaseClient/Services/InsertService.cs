using System.Linq;
using PathonDB.DatabaseClient.Models.Database;
using PathonDB.DatabaseClient.Models.Table;
using PathonDB.DatabaseClient.Utils;
using PathonDB.DatabaseClient.Validators;

namespace PathonDB.DatabaseClient.Services {
    public class InsertService : Service {
        public InsertService(IDatabase database) : base(database) {}

        public object PerformQuery(string query) {
            new InsertValidator(this._database).Validate(query);
            this.InsertRow(query);

            return null;
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