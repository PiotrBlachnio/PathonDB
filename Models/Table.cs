using System;
using System.Collections.Generic;
using System.Linq;
using JsonDatabase.Services;

namespace JsonDatabase.Models {
    public class Table {
        private readonly Dictionary<string, Column> _columns = new Dictionary<string, Column>();
        private readonly IList<Guid> _idList = new List<Guid>();
        public string Name;

        public Table(string name) {
            Name = name;
        }

        public void AddColumn(Column column) {
            _columns.Add(column.GetProperties().Name, column);
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

        public void AddRow(string[] columnNames, string[] values) {
            var id = Guid.NewGuid();
            _idList.Add(id);

            for(var i = 0; i < columnNames.Length; i++) {
                _columns[columnNames[i]].InsertData(id, UtilService.TransformStringValueToRealValue(values[i]));
            }
        }
    }
}