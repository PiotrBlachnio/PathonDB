namespace PathonDB.Models.Column {
    public class Row {
        public string Id { get; set; }
        public object Value { get; set; }

        public Row(string id, object value) {
            this.Id = id;
            this.Value = value;
        }
    }
}