using JsonDatabase.Models;

namespace JsonDatabase.Services {
    public class InsertService : Service {
        public InsertService(Database database) : base(database) {}

        public override void PerformQuery(string query) {
            this.InsertRow(query);
        }

        private void InsertRow(string query) {
            query = query.Substring(0, query.Length - 2);
            var tableName = query.Split(" ")[2];

            var columnNames = query.Split("(")[1].Split(")")[0].Trim().Split(",");
            var values = query.Split("(")[2].Trim().Split(",");

            _database.GetTable(tableName).AddRow(columnNames, values);
        }
    }
}