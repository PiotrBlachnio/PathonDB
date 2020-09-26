using System;
using Newtonsoft.Json;
using PathonDB.Exceptions.General;
using PathonDB.Services;

namespace PathonDB.Models.Database {
    public class Client : IClient {
        private IDatabase _database { get; } = new Database();

        public void ExecuteQuery(string[] queries) {
            foreach(var q in queries) {
                var query = q.TrimStart();
                var arguments = query.Split(" ");

                switch(arguments[0].ToUpper()) {
                    case "CREATE":
                        new CreateService(this._database).PerformQuery(query);
                        break;
                    case "INSERT":
                        new InsertService(this._database).PerformQuery(query);
                        break;
                    case "SELECT":
                        this.PrintAsJson(new SelectService(this._database).GetRecords(query));
                        break;
                    default:
                        throw new MalformedArgumentsException();
                }
            }
        }

        private void PrintAsJson(object data) {
            Console.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));
        }
    }
}