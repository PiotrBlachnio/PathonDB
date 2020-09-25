namespace PathonDB.Models.Column {
    public class Properties {
        public string Name { get; private set; }
        public string Type { get; private set; }

        public Properties(string name, string type) {
            Name = name;
            Type = type;
        }
    }
}