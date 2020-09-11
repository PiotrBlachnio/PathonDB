using System;
using System.Collections.Generic;
using System.Linq;
using PathonDB.Utils;

namespace PathonDB.Models {
    public class Table : ITable {
        private readonly Dictionary<string, Column> _columns = new Dictionary<string, Column>();
        private readonly IList<Guid> _idList = new List<Guid>();
        public string Name { get; set; }

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

        public void AddRow(string[] columns, string[] values) {
            var id = Guid.NewGuid();
            _idList.Add(id);

            for(var i = 0; i < columns.Length; i++) {
                _columns[columns[i]].InsertData(id, GeneralUtils.TransformStringValueToRealValue(values[i]));
            }
        }

        public Dictionary<string, object> GetRowById(Guid id) {
            var row = new Dictionary<string, object>() {};
            
            foreach(var entry in _columns) {
                row.Add(entry.Key, entry.Value.GetData(id));
            }

            return row;
        }

        public IList<Guid> GetIdList() {
            return _idList;
        }
    }
}