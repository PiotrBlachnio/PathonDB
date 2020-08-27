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
                    break;
                default:
                    throw new InvalidQueryArgumentsException(arguments[1]);
            }
        }

        private void CreateTable(string query) {
            var tableName = UtilService.GetTableName(query);


        }
    }
}