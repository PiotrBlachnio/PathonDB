namespace PathonDB.Models.Table {
    public class Condition {
        public string ColumnName { get; private set; }
        public string Value { get; private set; }

        public Condition(string columnName, string value) {
            this.ColumnName = columnName;
            this.Value = value;
        }
    }
}