using System.Collections.Generic;

namespace JsonDatabase.Services {
    public abstract class Service {
        protected readonly Dictionary<string, dynamic> _storage;

        public Service(Dictionary<string, dynamic> storage) {
            _storage = storage;
        }

        public abstract void PerformQuery(string query);
    }
}