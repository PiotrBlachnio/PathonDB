using System;
using System.Collections.Generic;

namespace PathonDB.Models {
    public class ColumnData {
        public Guid idList { get; set; }
        
        public Dictionary<string, object[]> rows { get; set; }
    }
}