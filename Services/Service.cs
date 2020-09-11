using PathonDB.Models;

namespace PathonDB.Services {
    public abstract class Service {
        protected readonly IDatabase _database;

        public Service(IDatabase database) {
            _database = database;
        }

        public abstract void PerformQuery(string query);
    }
}