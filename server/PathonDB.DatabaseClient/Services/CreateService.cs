using PathonDB.DatabaseClient.Models.Database;
using PathonDB.DatabaseClient.Models.Column;
using PathonDB.DatabaseClient.Models.Table;
using PathonDB.DatabaseClient.Utils;
using PathonDB.DatabaseClient.Validators.Create;

namespace PathonDB.DatabaseClient.Services {
    public class CreateService : Service {
        public CreateService(IDatabase database) : base(database) {}

        public void PerformQuery(string query) {
            new CreateValidator(this._database).Validate(query);
            CreateTable(query);
        }

        private void CreateTable(string query) {
            var arguments = CreateUtils.GetArgumentsFromQuery(query.Remove(query.Length - 2));
            var tableName = CreateUtils.GetTableNameFromQuery(query);
            var columns = CreateUtils.GetColumnsFromArguments(arguments);

            var table = new Table(tableName);
            
            foreach(var element in columns) {
                var column = new Column(new Properties(element[0], element[1]));
                table.AddColumn(column);
            }

            this._database.AddTable(table);
        }
    }
}