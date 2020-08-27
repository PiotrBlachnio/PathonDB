using JsonDatabase.Models;

namespace JsonDatabase.Services {
    public abstract class Service {
        protected readonly Database _database;

        public Service(Database database) {
            _database = database;
        }

        public abstract void PerformQuery(string query);
    }
}