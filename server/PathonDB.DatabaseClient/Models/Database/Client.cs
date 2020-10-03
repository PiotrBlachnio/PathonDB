using PathonDB.DatabaseClient.Exceptions.General;
using PathonDB.DatabaseClient.Services;

namespace PathonDB.DatabaseClient.Models.Database {
    public class Client : IClient {
        private IDatabase _database { get; } = new Database();

        public object ExecuteQuery(string[] queries) {
            foreach(var q in queries) {
                if(q == null) throw new QueryNotExistException();
                var query = q.TrimStart();
                var arguments = query.Split(" ");

                switch(arguments[0].ToUpper()) {
                    case "CREATE":
                        return new CreateService(this._database).PerformQuery(query);
                    case "INSERT":
                        return new InsertService(this._database).PerformQuery(query);
                    case "SELECT":
                        return new SelectService(this._database).PerformQuery(query);
                    default:
                        throw new MalformedArgumentsException();
                }
            }

            return null;
        }
    }
}