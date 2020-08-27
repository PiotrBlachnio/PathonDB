using System.Collections.Generic;

namespace JsonDatabase.Models {
    public class Table {
        private readonly Dictionary<string, Column<dynamic>> _columns = new Dictionary<string, Column<dynamic>>();
        public string Name;

        public Table(string name) {
            Name = name;
        }

        public void AddColumn(Column<dynamic> column) {
            _columns.Add((string) column.GetProperties()["Name"], column);
        }
    }
}