using JsonDatabase.Exceptions;
using JsonDatabase.Models;
using JsonDatabase.Validators.Create;

namespace JsonDatabase.Services {
    public class CreateService : Service {
        public CreateService(Database database) : base(database) {}

        public override void PerformQuery(string query) {
            new CreateTableValidator(this._database).Validate(query);
            CreateTable(query);
        }

        private void CreateTable(string query) {
            var tableName = UtilService.GetTableName(query);
            var parameters = UtilService.GetParameters(query);

            var table = new Table(tableName.ToLower());
            
            foreach(var parameter in parameters) {
                var column = new Column(new Properties(parameter[0], parameter[1]));
                table.AddColumn(column);
            }

            _database.AddTable(table);
        }
    }
}