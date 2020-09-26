using System.Collections.Generic;

namespace PathonDB.Models.Table {
    public class Record {
        public string Id { get; set; }
        public IList<string> ColumnNames { get; private set; }
        public IList<string> Values { get; private set; }

        public Record(string[] columnNames = null, string[] values = null) {
            this.ColumnNames = columnNames == null ? new string[] {} : columnNames;
            this.Values = values == null ? new string[] {} : values;
        }

        public void AddColumnName(string columnName) {
            this.ColumnNames.Add(columnName);
        }

        public void AddValue(string value) {
            this.Values.Add(value);
        }
    }
}