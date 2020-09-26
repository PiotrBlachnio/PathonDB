using System;
using System.Collections.Generic;
using System.Linq;
using PathonDB.Models.Column;
using PathonDB.Utils;

namespace PathonDB.Models.Table {
    public class Table : ITable {
        private List<IColumn> _columns { get; }
        public IList<string> IdList { get; private set; }
        public string Name { get; private set; }

        public Table(string name) {
            this._columns = new List<IColumn>();
            this.IdList = new List<string>();

            this.Name = name;
        }

        public void AddColumn(IColumn column) {
            this._columns.Add(column);
        }

        public Properties[] GetColumnProperties() {
            return this._columns.Select(x => x.Properties).ToArray();
        }

        public void AddRow(string[] columns, string[] values) {
            var id = Guid.NewGuid().ToString();
            IdList.Add(id);

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

        public RowsData GetRowsData(string[] columnNames = null) {
            var output = new RowsData();
            var rows = new Dictionary<string, object[]>();

            foreach(var column in _columns) {   
                if(columnNames == null || columnNames.Contains(column.Properties.Name)) {
                    rows.Add(column.Properties.Name, column.GetRows().Select(x => x.Value).ToArray());
                }
            }

            output.Rows = rows;
            if(columnNames == null || columnNames.Select(x => x.ToLower()).Contains("id")) output.IdList = IdList.Select(x => x.ToString()).ToArray();
        
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