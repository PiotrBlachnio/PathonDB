namespace PathonDB.Models.Table {
    public class Record {
        public string Id { get; set; }
        public string[] ColumnNames { get; private set; }
        public string[] Values { get; private set; }

        public Record(string[] columnNames, string[] values) {
            this.ColumnNames = columnNames;
            this.Values = values;
        }
    }
}