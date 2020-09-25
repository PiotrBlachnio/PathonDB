using System.Collections.Generic;
using System.Linq;

namespace PathonDB.Models {
    public class Database : IDatabase {
        private readonly Dictionary<string, ITable> _tables = new Dictionary<string, ITable>();

        public string[] GetTableNames() {
            return _tables.Keys.ToArray();
        }
        
        public ITable GetTable(string tableName) {
            return _tables[tableName];
        }

        public void AddTable(ITable table) {
            _tables.Add(table.Name, table);
        }
    }
}