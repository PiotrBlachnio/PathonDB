using System;
using System.Linq;
using JsonDatabase.Models;
using JsonDatabase.Utils;
using JsonDatabase.Validators;

namespace JsonDatabase.Services {
    public class InsertService : Service {
        public InsertService(Database database) : base(database) {}

        public override void PerformQuery(string query) {
            new InsertValidator(this._database).Validate(query);
            this.InsertRow(query);
        }

        private void InsertRow(string query) {
            var arguments = InsertUtils.GetArgumentsFromQuery(query.Substring(0, query.Length - 2));
            var tableName = InsertUtils.GetTableNameFromQuery(query);

            var columns = InsertUtils.GetColumnsFromArguments(arguments).ToArray();
            var values = InsertUtils.GetValuesFromArguments(arguments).ToArray();

            _database.GetTable(tableName).AddRow(columns, values);
        }
    }
}