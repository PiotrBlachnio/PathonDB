namespace PathonDB.Server.Models {
    public interface IDatabaseClient {
        bool ContainsKey(string key);

        void AddClient(string key);

        object PerformQuery(string key, string query);
    }
}