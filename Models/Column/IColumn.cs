using System;
using System.Linq;

namespace PathonDB.Models.Column {
    public interface IColumn {
        Properties GetProperties();

        void InsertData(Guid id, object data);

        object GetDataById(Guid id);

        object[] GetMultipleRowsByIdList(string[] idList);

        object[] GetData();

        string[] FindIdsByData(object data);
    }
}