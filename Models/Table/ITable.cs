using System.Collections.Generic;
using PathonDB.Models.Column;

namespace PathonDB.Models.Table {
    public interface ITable {
        string Name { get; }

        List<string> IdList { get; }
        
        void AddColumn(IColumn column);

        Properties[] GetColumnProperties();

        void AddRecord(Record record);

        Record GetRecordById(string id);

        Record[] GetRecords(string[] columnNames, Condition condition);

        RowsData GetRowsData(string[] columnNames = null);

        RowsData GetRowsDataWithCondition(string[] condition, string[] columnNames = null);
    }
}