using System.Collections.Generic;

namespace JsonDatabase.Models {
    public interface ITable {
        void AddColumn(Column column);

        string[] GetColumnNames();

        Dictionary<string, string> GetColumnTypes();

        void AddRow(string[] columns, string[] values);
    }
}