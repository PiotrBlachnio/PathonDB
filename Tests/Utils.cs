using System.Collections.Generic;
using PathonDB.Models;
using PathonDB.Models.Column;
using PathonDB.Models.Table;

namespace PathonDB.Tests {
    public class MockedTable : ITable {
        public string Name { get; set; }

        public IList<string> IdList { get; private set; }

        public void AddColumn(IColumn column) {
            throw new System.NotImplementedException();
        }

        public void AddRecord(string[] columns, string[] values) {
            throw new System.NotImplementedException();
        }

        public RowsData GetRowsData(string[] columnNames = null)
        {
            throw new System.NotImplementedException();
        }

        public IList<string> GetIdList() {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, object> GetRowById(string id) {
            throw new System.NotImplementedException();
        }

        public RowsData GetRowsDataWithCondition(string[] condition, string[] columnNames = null)
        {
            throw new System.NotImplementedException();
        }

        public Properties[] GetColumnProperties()
        {
            return new Properties[] {
                new Properties("email", "text"),
                new Properties("phoneNumber", "int"),
                new Properties("isAdult", "boolean")
            };
        }
    }
}