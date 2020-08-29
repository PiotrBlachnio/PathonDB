using JsonDatabase.Exceptions;
using JsonDatabase.Models;
using JsonDatabase.Validators.Create;

namespace JsonDatabase.Services {
    public class CreateService : Service {
        public CreateService(Database database) : base(database) {}

        public override void PerformQuery(string query) {
            var arguments = query.Split(" ");

            switch(arguments[1].ToUpper()) {
                case "TABLE":
                    new CreateTableValidator(_database).Validate(query);
                    CreateTable(query);

                    break;
                default:
                    throw new InvalidQueryArgumentsException(arguments[1]);
            }
        }

        private void CreateTable(string query) {
            var tableName = UtilService.GetTableName(query);
            var parameters = UtilService.GetParameters(query);

            var table = new Table(tableName.ToLower());
            
            foreach(var parameter in parameters) {
                var column = new Column(new Properties(parameter[0].ToLower(), parameter[1]));
                table.AddColumn(column);
            }

            _database.AddTable(table);
        }
    }
}