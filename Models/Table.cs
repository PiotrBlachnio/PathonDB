using System.Collections.Generic;
using System.Linq;

namespace JsonDatabase.Models {
    public class Table {
        private readonly Dictionary<string, Column> _columns = new Dictionary<string, Column>();
        private readonly IList<string> _idList = new List<string>();
        public string Name;

        public Table(string name) {
            Name = name;
        }

        public void AddColumn(Column column) {
            _columns.Add((string) column.GetProperties().Name, column);
        }

        public string[] GetColumnNames() {
            return _columns.Keys.ToArray();
        }

        public Dictionary<string, string> GetColumnsTypes() {
            var columnsTypes = new Dictionary<string ,string>();

            foreach(var column in _columns) {
                columnsTypes.Add(column.Value.GetProperties().Name, column.Value.GetProperties().Type);
            }

            return columnsTypes;
        }
    }
}