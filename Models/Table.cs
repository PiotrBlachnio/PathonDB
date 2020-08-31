using System;
using System.Collections.Generic;
using System.Linq;

namespace JsonDatabase.Models {
    public class Table {
        private readonly Dictionary<string, Column> _columns = new Dictionary<string, Column>();
        private readonly IList<Guid> _idList = new List<Guid>();
        public string Name;

        public Table(string name) {
            Name = name;
        }

        public void AddColumn(Column column) {
            _columns.Add((string) column.GetProperties().Name, column);
        }

        public void AddRow(string[] columnNames, string[] values) {
            var id = Guid.NewGuid();
            _idList.Add(id);

            for(var i = 0; i < columnNames.Length; i++) {
                var value = values[i];
                if(value[0] == '"') {
                    value.Remove(0, 1);
                    value.Remove(value.Length - 1, 1);

                    _columns[columnNames[i]].InsertData(id, value);
                } else if(value == "true" || value == "false") {
                    value = value.First().ToString().ToUpper() + value.Substring(1);
                    _columns[columnNames[i]].InsertData(id, Boolean.Parse(value));
                } else {
                    _columns[columnNames[i]].InsertData(id, Int32.Parse(value));
                }
            }
        }

        public string[] GetColumnNames() {
            return _columns.Keys.ToArray();
        }

        public Dictionary<string, string> GetColumnTypes() {
            var columnTypes = new Dictionary<string ,string>();

            foreach(var column in _columns) {
                columnTypes.Add(column.Value.GetProperties().Name, column.Value.GetProperties().Type);
            }

            return columnTypes;
        }
    }
}