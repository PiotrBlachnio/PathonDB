using System.Collections.Generic;
using PathonDB.DatabaseClient.Models.Column;

namespace PathonDB.DatabaseClient.Models.Table {
    public interface ITable {
        string Name { get; }

        List<string> IdList { get; }
        
        void AddColumn(IColumn column);

        Properties[] GetColumnProperties();

        void AddRecord(Record record);

        Record GetRecordById(string id);

        Record[] GetRecords(string[] columnNames, Condition condition);
    }
}