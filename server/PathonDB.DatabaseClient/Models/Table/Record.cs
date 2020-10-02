using System.Collections.Generic;

namespace PathonDB.DatabaseClient.Models.Table {
    public class Record {
        public string Id { get; set; }
        public List<string> ColumnNames { get; private set; }
        public List<object> Values { get; private set; }

        public Record(List<string> columnNames = null, List<object> values = null) {
            this.ColumnNames = columnNames == null ? new List<string>() : columnNames;
            this.Values = values == null ? new List<object>() : values;
        }

        public void AddColumnName(string columnName) {
            this.ColumnNames.Add(columnName);
        }

        public void AddValue(object value) {
            this.Values.Add(value);
        }
    }
}