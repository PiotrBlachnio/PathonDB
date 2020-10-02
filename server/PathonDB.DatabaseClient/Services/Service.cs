using PathonDB.DatabaseClient.Models.Database;

namespace PathonDB.DatabaseClient.Services {
    public abstract class Service {
        protected readonly IDatabase _database;

        public Service(IDatabase database) {
            _database = database;
        }
    }
}