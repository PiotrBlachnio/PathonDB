using JsonDatabase.Models;
using JsonDatabase.Utils;
using JsonDatabase.Validators.Create;

namespace JsonDatabase.Services {
    public class CreateService : Service {
        public CreateService(Database database) : base(database) {}

        public override void PerformQuery(string query) {
            new CreateTableValidator(this._database).Validate(query);
            CreateTable(query);
        }

        private void CreateTable(string query) {
            var arguments = CreateUtils.GetArgumentsFromQuery(query);
            var tableName = CreateUtils.GetTableNameFromQuery(query);
            var columns = CreateUtils.GetColumnsFromArguments(arguments);

            var table = new Table(tableName);
            
            foreach(var element in columns) {
                var column = new Column(new Properties(element[0], element[1]));
                table.AddColumn(column);
            }

            _database.AddTable(table);
        }
    }
}