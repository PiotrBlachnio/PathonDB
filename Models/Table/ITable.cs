using System.Collections.Generic;
using PathonDB.Models.Column;

namespace PathonDB.Models.Table {
    public interface ITable {
        string Name { get; }

        IList<string> IdList { get; }
        
        void AddColumn(IColumn column);

        Properties[] GetColumnProperties();

        void AddRecord(string[] columnNames, string[] values);

        Dictionary<string, object> GetRowById(string id);

        RowsData GetRowsData(string[] columnNames = null);

        RowsData GetRowsDataWithCondition(string[] condition, string[] columnNames = null);
    }
}