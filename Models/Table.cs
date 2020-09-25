using System;
using System.Collections.Generic;
using System.Linq;
using PathonDB.Models.Column;
using PathonDB.Utils;

namespace PathonDB.Models {
    public class Table : ITable {
        private readonly Dictionary<string, IColumn> _columns = new Dictionary<string, IColumn>();
        private readonly IList<string> _idList = new List<string>();
        public string Name { get; set; }

        public Table(string name) {
            Name = name;
        }

        public void AddColumn(IColumn column) {
            _columns.Add(column.Properties.Name, column);
        }

        public string[] GetColumnNames() {
            return _columns.Keys.ToArray();
        }

        public Dictionary<string, string> GetColumnTypes() {
            var columnTypes = new Dictionary<string, string>();

            foreach(var column in _columns) {
                columnTypes.Add(column.Value.Properties.Name, column.Value.Properties.Type);
            }

            return columnTypes;
        }

        public void AddRow(string[] columns, string[] values) {
            var id = Guid.NewGuid().ToString();
            _idList.Add(id);

            for(var i = 0; i < columns.Length; i++) {
                var row = new Row(id, GeneralUtils.TransformStringValueToRealValue(values[i]));
                _columns[columns[i]].InsertRow(row);
            }
        }

        public Dictionary<string, object> GetRowById(string id) {
            var row = new Dictionary<string, object>() {};
            
            foreach(var entry in _columns) {
                row.Add(entry.Key, entry.Value.GetRowById(id));
            }

            return row;
        }

        public IList<string> GetIdList() {
            return _idList;
        }

        public RowsData GetRowsData(string[] columnNames = null) {
            var output = new RowsData();
            var rows = new Dictionary<string, object[]>();

            foreach(var column in _columns) {
                if(columnNames == null || columnNames.Contains(column.Key)) {
                    rows.Add(column.Key, column.Value.GetRows().Select(x => x.Value).ToArray());
                }          
            }

            output.Rows = rows;
            if(columnNames == null || columnNames.Select(x => x.ToLower()).Contains("id")) output.IdList = _idList.Select(x => x.ToString()).ToArray();
        
            return output;
        }

        public RowsData GetRowsDataWithCondition(string[] condition, string[] columnNames = null) {
            var output = new RowsData();
            var rows = new Dictionary<string, object[]>();

            var columnName = condition[0];
            var ids = columnName.ToLower() == "id" ? new string[] {condition[1]}: _columns[columnName].FindIdsByData(GeneralUtils.TransformStringValueToRealValue(condition[1])).ToArray();

            foreach(var column in _columns) {
                if(columnNames == null || columnNames.Contains(column.Key)) {
                    rows.Add(column.Key, column.Value.GetRows(ids).Select(x => x.Value).ToArray());
                }  
            }

            output.Rows = rows;
            if(columnNames == null || columnNames.Select(x => x.ToLower()).Contains("id")) output.IdList = ids;
            
            return output;
        }
    }
}