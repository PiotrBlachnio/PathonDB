using System;
using System.Collections.Generic;
using System.Linq;

namespace PathonDB.Models.Column {
    public class Column : IColumn {
        public Properties Properties { get; private set; }

        private Dictionary<string, object> _data { get; }

        public Column(Properties properties) {
            this.Properties = properties;
            this._data = new Dictionary<string, object>();
        }  

        public void InsertData(string id, object data) {
            _data.Add(id, data);
        }

        public object GetDataById(string id) {
            return _data[id];
        }

        public object[] GetMultipleRowsByIdList(string[] idList) {
            return _data.Where(x => idList.Contains(x.Key.ToString())).Select(x => x.Value).ToArray();
        }

        public object[] GetData() {
            return _data.Values.ToArray();
        }

        public string[] FindIdsByData(object data) {
            return _data.Where(x => x.Value.Equals(data)).Select(x => x.Key.ToString()).ToArray();
        }
    }
}