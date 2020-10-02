using PathonDB.Models.Database;

namespace PathonDB.Services {
    public abstract class Service {
        protected readonly IDatabase _database;

        public Service(IDatabase database) {
            _database = database;
        }
    }
}