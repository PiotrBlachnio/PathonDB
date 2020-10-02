namespace PathonDB.DatabaseClient.Models.Database {
    public interface IClient {
        void ExecuteQuery(string[] queries);
    }
}