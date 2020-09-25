using System;
using System.Collections.Generic;
using PathonDB.Models.Column;

namespace PathonDB.Models {
    public interface ITable {
        string Name { get; set; }
        
        void AddColumn(IColumn column);

        string[] GetColumnNames();

        Dictionary<string, string> GetColumnTypes();

        void AddRow(string[] columns, string[] values);

        Dictionary<string, object> GetRowById(Guid id);

        RowsData GetRowsData(string[] columnNames = null);

        IList<Guid> GetIdList();

        RowsData GetRowsDataWithCondition(string[] condition, string[] columnNames = null);
    }
}