using System.Collections.Generic;

namespace JsonDatabase.Models {
    public class Table {
        private Dictionary<string, Column> Columns = new Dictionary<string, Column>();
    }
}