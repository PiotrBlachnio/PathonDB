using System.Collections.Generic;
using System.Linq;
using PathonDB.DatabaseClient.Models.Table;

namespace PathonDB.DatabaseClient.Models.Database {
    public class Database : IDatabase {
        public List<ITable> Tables { get; private set; } = new List<ITable>();

        public string[] GetTableNames() {
            return this.Tables.Select(x => x.Name).ToArray();
        }
        
        public ITable GetTable(string tableName) {
            return this.Tables.First(x => x.Name == tableName);
        }

        public void AddTable(ITable table) {
            this.Tables.Add(table);
        }
    }
}