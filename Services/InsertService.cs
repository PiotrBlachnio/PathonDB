using System.Linq;
using JsonDatabase.Models;
using JsonDatabase.Validators;

namespace JsonDatabase.Services {
    public class InsertService : Service {
        public InsertService(Database database) : base(database) {}

        public override void PerformQuery(string query) {
            new InsertValidator(this._database).Validate(query);
            this.InsertRow(query);
        }

        private void InsertRow(string query) {
            query = query.Substring(0, query.Length - 2);
            var tableName = query.Split(" ")[2];

            var columnNames = query.Split("(")[1].Split(")")[0].Split(",").Select(x => x.Trim()).ToArray();
            var values = query.Split("(")[2].Trim().Split(",").Select(x => x.Trim()).ToArray();

            _database.GetTable(tableName).AddRow(columnNames, values);
        }
    }
}