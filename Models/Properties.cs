namespace JsonDatabase.Models {
    public class Properties {
        public readonly string Name;
        public readonly string Type;

        public Properties(string name, string type) {
            Name = name;
            Type = type;
        }
    }
}