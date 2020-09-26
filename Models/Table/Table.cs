using System;
using System.Collections.Generic;
using System.Linq;
using PathonDB.Models.Column;
using PathonDB.Utils;

namespace PathonDB.Models.Table {
    public class Table : ITable {
        private List<IColumn> _columns { get; }
        private readonly IList<string> _idList = new List<string>();
        public string Name { get; set; }

        public Table(string name) {
            _columns = new List<IColumn>();
            Name = name;
        }

        public void AddColumn(IColumn column) {
            _columns.Add(column);
        }

        public string[] GetColumnNames() {
            return _columns.Select(x => x.Properties.Name).ToArray();
        }

        public Dictionary<string, string> GetColumnTypes() {
            var columnTypes = new Dictionary<string, string>();

            foreach(var column in _columns) {
                columnTypes.Add(column.Properties.Name, column.Properties.Type);
            }

            return columnTypes;
        }

        public void AddRow(string[] columns, string[] values) {
            var id = Guid.NewGuid().ToString();
            _idList.Add(id);

            for(var i = 0; i < columns.Length; i++) {
                var row = new Row(id, GeneralUtils.TransformStringValueToRealValue(values[i]));
                _columns.First(x => x.Properties.Name == columns[i]).InsertRow(row);
            }
        }

        public Dictionary<string, object> GetRowById(string id) {
            var row = new Dictionary<string, object>() {};
            
            foreach(var entry in _columns) {
                row.Add(entry.Properties.Name, entry.GetRowById(id).Value);
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
                if(columnNames == null || columnNames.Contains(column.Properties.Name)) {
                    rows.Add(column.Properties.Name, column.GetRows().Select(x => x.Value).ToArray());
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
            var existingColumn = _columns.First(x => x.Properties.Name == columnName);
            
            var ids = columnName.ToLower() == "id" ? new string[] {condition[1]}: existingColumn.GetFilteredIdList(GeneralUtils.TransformStringValueToRealValue(condition[1]));

            foreach(var column in _columns) {

                if(columnNames == null || columnNames.Contains(column.Properties.Name)) {
                    rows.Add(column.Properties.Name, column.GetRows(ids).Select(x => x.Value).ToArray());
                } 
                
            }

            output.Rows = rows;
            if(columnNames == null || columnNames.Select(x => x.ToLower()).Contains("id")) output.IdList = ids;
            
            return output;
        }
    }
}