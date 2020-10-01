using System;
using System.Collections.Generic;
using System.Linq;

namespace PathonDB.Models.Column {
    public class Column : IColumn {
        public Properties Properties { get; private set; }
        private List<Row> _rows { get; }

        public Column(Properties properties) {
            this.Properties = properties;
            this._rows = new List<Row>();
        }  

        public void InsertRow(Row row) {
            this._rows.Add(row);
        }

        public Row GetRowById(string id) {
            return this._rows.First(x => x.Id == id);
        }

        public Row[] GetRows(string[] idList = null) {
            Func<Row, bool> validateRow = (Row x) => idList == null ? true : idList.Contains(x.Id);
            return this._rows.Where(validateRow).ToArray();
        }

        public string[] GetFilteredIdList(object value) {
            return this._rows.Where(x => x.Value.Equals(value)).Select(x => x.Id).ToArray();
        }
    }
}