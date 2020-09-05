using JsonDatabase.Models;

namespace JsonDatabase.Services {
    public abstract class Service {
        protected readonly IDatabase _database;

        public Service(IDatabase database) {
            _database = database;
        }

        public abstract void PerformQuery(string query);
    }
}