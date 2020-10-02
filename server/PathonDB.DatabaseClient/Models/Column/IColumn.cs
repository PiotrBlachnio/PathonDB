namespace PathonDB.Models.Column {
    public interface IColumn {
        Properties Properties { get; }

        void InsertRow(Row row);

        Row GetRowById(string id);

        Row[] GetRows(string[] idList = null);

        string[] GetFilteredIdList(object value);
    }
}