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

        public void AddRecord(Record record) {
            record.Id = Guid.NewGuid().ToString();
            this.IdList.Add(record.Id);

            for(var i = 0; i < record.ColumnNames.Count(); i++) {
                var row = new Row(record.Id, record.Values[i]);
                this._columns.First(x => x.Properties.Name == record.ColumnNames[i]).InsertRow(row);
            }
        }
        
        public Record GetRecordById(string id) {
            var record = new Record();

            foreach(var column in this._columns) {
                record.AddColumnName(column.Properties.Name);
                record.AddValue(column.GetRowById(id).Value);
            }

            return record;
        }

        public Record[] GetRecords(string[] columnNames, string[] condition) {
            var output = new List<Record>();
            var recordIds = condition == null ? this.IdList : null;
            var mutualColumns = columnNames == null ? this._columns : this._columns.Where(x => columnNames.Contains(x.Properties.Name));

            foreach(var id in recordIds) {
                var names = mutualColumns.Select(x => x.Properties.Name).ToList();
                var values = mutualColumns.Select(x => x.GetRowById(id).Value).ToList();

                var record = new Record(names, values);
                if(columnNames.Any(x => x.ToLower() == "id")) record.Id = id;

                output.Add(record);
            }

            return output.ToArray();
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
            if(columnNames == null || columnNames.Select(x => x.ToLower()).Contains("id")) output.IdList = IdList.ToArray();
        
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