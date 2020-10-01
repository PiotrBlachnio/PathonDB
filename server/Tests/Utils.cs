using System.Collections.Generic;
using PathonDB.Models;
using PathonDB.Models.Column;
using PathonDB.Models.Table;

namespace PathonDB.Tests {
    public class MockedTable : ITable {
        public string Name { get; set; }

        public List<string> IdList { get; private set; }

        public void AddColumn(IColumn column) {
            throw new System.NotImplementedException();
        }

        public void AddRecord(Record record) {
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

        public Record GetRecordById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Record[] GetRecords(string[] columnNames, Condition condition)
        {
            throw new System.NotImplementedException();
        }
    }
}