namespace PathonDB.Models.Column {
    public interface IColumn {
        Properties Properties { get; }

        void InsertData(string id, object data);

        object GetDataById(string id);

        object[] GetMultipleRowsByIdList(string[] idList);

        object[] GetData();

        string[] FindIdsByData(object data);
    }
}