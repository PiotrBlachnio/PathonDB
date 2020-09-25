using System.Collections.Generic;
using PathonDB.Models;
using PathonDB.Models.Column;

namespace PathonDB.Tests {
    public class MockedTable : ITable {
        public string Name { get; set; }

        public void AddColumn(IColumn column) {
            throw new System.NotImplementedException();
        }

        public void AddRow(string[] columns, string[] values) {
            throw new System.NotImplementedException();
        }

        public RowsData GetRowsData(string[] columnNames = null)
        {
            throw new System.NotImplementedException();
        }

        public string[] GetColumnNames() {
            return new string[2] { "email", "phoneNumber" };
        }

        public Dictionary<string, string> GetColumnTypes() {
            return new Dictionary<string, string>() {
                    {"email", "text"},
                    {"phoneNumber", "int"},
                    {"isAdult", "boolean"}
            };
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
    }
}