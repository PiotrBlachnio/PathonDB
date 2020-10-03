namespace PathonDB.DatabaseClient.Models.Database {
    public interface IClient {
        object ExecuteQuery(string[] queries);
    }
}