using System.Collections.Generic;
using PathonDB.Models.Table;

namespace PathonDB.Models.Database {
    public interface IDatabase {
        List<ITable> Tables { get; }
        
        string[] GetTableNames();

        ITable GetTable(string tableName);

        void AddTable(ITable table);
    }
}