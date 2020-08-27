using System.Collections.Generic;

namespace JsonDatabase.Models {
    public class Table {
        private readonly Dictionary<string, Column> _columns = new Dictionary<string, Column>();
        public string Name;

        public Table(string name) {
            Name = name;
        }

        public void AddColumn(Column column) {
            _columns.Add((string) column.GetProperties().Name, column);
        }
    }
}