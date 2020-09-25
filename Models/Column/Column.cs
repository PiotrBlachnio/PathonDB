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

        public void InsertData(string id, object data) {
            this._rows.Add(new Row(id, data));
        }

        public Row GetDataById(string id) {
            return this._rows.First(x => x.Id == id);
        }

        public object[] GetMultipleRowsByIdList(string[] idList) {
            return this._rows.Where(x => idList.Contains(x.Id)).Select(x => x.Value).ToArray();
        }

        public object[] GetData() {
            return _rows.Select(x => x.Value).ToArray();
        }

        public string[] FindIdsByData(object data) {
            return _rows.Where(x => x.Value.Equals(data)).Select(x => x.Id).ToArray();
        }
    }
}