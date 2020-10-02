namespace PathonDB.Models.Database {
    public interface IClient {
        void ExecuteQuery(string[] queries);
    }
}