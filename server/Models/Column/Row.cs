namespace PathonDB.Models.Column {
    public class Row {
        public string Id { get; private set; }
        public object Value { get; private set; }

        public Row(string id, object value) {
            this.Id = id;
            this.Value = value;
        }
    }
}