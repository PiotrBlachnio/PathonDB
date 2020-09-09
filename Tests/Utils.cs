using System;
using System.Collections.Generic;
using JsonDatabase.Models;

namespace JsonDatabase.Tests {
    public class MockedTable : ITable {
        public void AddColumn(Column column) {
            throw new System.NotImplementedException();
        }

        public void AddRow(string[] columns, string[] values) {
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

        public IList<System.Guid> GetIdList() {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, object> GetRowById(System.Guid id) {
            throw new System.NotImplementedException();
        }
    }
}