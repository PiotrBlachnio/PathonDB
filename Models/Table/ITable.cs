using System.Collections.Generic;
using PathonDB.Models.Column;

namespace PathonDB.Models.Table {
    public interface ITable {
        string Name { get; set; }
        
        void AddColumn(IColumn column);

        string[] GetColumnNames();

        Dictionary<string, string> GetColumnTypes();

        void AddRow(string[] columns, string[] values);

        Dictionary<string, object> GetRowById(string id);

        RowsData GetRowsData(string[] columnNames = null);

        IList<string> GetIdList();

        RowsData GetRowsDataWithCondition(string[] condition, string[] columnNames = null);
    }
}