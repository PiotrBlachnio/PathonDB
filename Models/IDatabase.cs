using PathonDB.Models.Table;

namespace PathonDB.Models {
    public interface IDatabase {
        string[] GetTableNames();

        ITable GetTable(string tableName);

        void AddTable(ITable table);
    }
}