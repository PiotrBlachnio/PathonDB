namespace PathonDB.Models.Column {
    public class Properties {
        public string Name { get; set; }
        
        public string Type { get; set; }

        public Properties(string name, string type) {
            Name = name;
            Type = type;
        }
    }
}