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
            var id = new Guid();
            _idList.Add(id);

            for(var i = 0; i < columnNames.Length; i++) {
                var value = values[i];
                if(value[0] == '"') {
                    value.Remove(0, 1);
                    value.Remove(value.Length - 1, 1);
                }

                _columns[columnNames[i]].InsertData(id, value);
            }
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