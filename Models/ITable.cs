using System;
using System.Collections.Generic;

namespace PathonDB.Models {
    public interface ITable {
        void AddColumn(Column column);

        string[] GetColumnNames();

        Dictionary<string, string> GetColumnTypes();

        void AddRow(string[] columns, string[] values);

        Dictionary<string, object> GetRowById(Guid id);

        IList<Guid> GetIdList();
    }
}