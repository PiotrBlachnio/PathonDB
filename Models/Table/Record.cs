namespace PathonDB.Models.Table {
    public class Record {
        public string Id { get; set; }
        public string[] ColumnNames { get; private set; }
        public object[] Values { get; private set; }

        public Record(string[] columnNames, object[] values) {
            this.ColumnNames = columnNames;
            this.Values = values;
        }
    }
}