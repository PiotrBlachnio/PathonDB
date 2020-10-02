using System.Collections.Generic;
using PathonDB.DatabaseClient.Models.Table;

namespace PathonDB.DatabaseClient.Models.Database {
    public interface IDatabase {
        List<ITable> Tables { get; }
        
        string[] GetTableNames();

        ITable GetTable(string tableName);

        void AddTable(ITable table);
    }
}