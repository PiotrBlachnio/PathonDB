using System;
using System.Collections.Generic;
using System.Linq;
using PathonDB.Models.Column;
using PathonDB.Utils;

namespace PathonDB.Models.Table {
    public class Table : ITable {
        private List<IColumn> _columns { get; }
        public List<string> IdList { get; private set; }
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

        public Record[] GetRecords(string[] columnNames, Condition condition) {
            var output = new List<Record>();
            var recordIds = this.IdList;

            if(condition != null) {
                if(condition.ColumnName.ToLower() == "id") recordIds = new List<string>() { condition.Value };
                else {
                    var selectedColumn = this._columns.First(x => x.Properties.Name == condition.ColumnName);
                    var realValue = GeneralUtils.TransformStringValueToRealValue(condition.Value);

                    recordIds = selectedColumn.GetFilteredIdList(realValue).ToList();
                }
            }

            var mutualColumns = columnNames == null ? this._columns : this._columns.Where(x => columnNames.Contains(x.Properties.Name));

            foreach(var id in recordIds) {
                var names = mutualColumns.Select(x => x.Properties.Name).ToList();
                var values = mutualColumns.Select(x => x.GetRowById(id).Value).ToList();

                var record = new Record(names, values);
                if(columnNames == null || columnNames.Any(x => x.ToLower() == "id")) record.Id = id;

                output.Add(record);
            }

            return output.ToArray();
        }
    }
}