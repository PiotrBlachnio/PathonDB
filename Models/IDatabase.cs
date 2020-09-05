namespace JsonDatabase.Models {
    public interface IDatabase {
        string[] GetTableNames();

        Table GetTable(string tableName);

        void AddTable(Table table);
    }
}