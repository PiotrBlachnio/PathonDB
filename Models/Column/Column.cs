using System;
using System.Collections.Generic;
using System.Linq;

namespace PathonDB.Models.Column {
    public class Column : IColumn {
        private Properties Properties { get; }
        private readonly Dictionary<Guid, object> _data = new Dictionary<Guid, object>();

        public Column(Properties properties) {
            Properties = properties;
        }  

        public void InsertData(Guid id, object data) {
            _data.Add(id, data);
        }

        public object GetDataById(Guid id) {
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