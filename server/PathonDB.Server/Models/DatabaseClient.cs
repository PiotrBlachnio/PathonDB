using System.Collections.Generic;
using PathonDB.DatabaseClient.Models.Database;

namespace PathonDB.Server.Models {
    public class DatabaseClient : IDatabaseClient {
        private readonly Dictionary<string, Client> _database = new Dictionary<string, Client>();

        public bool ContainsKey(string key) {
            return _database.ContainsKey(key);
        }

        public void AddClient(string key) {
            _database.Add(key, new Client());
        }

        public object PerformQuery(string key, string query) {
            return _database[key].ExecuteQuery(new string[] { query });
        }
    }
}