using System;
using System.Collections.Generic;

namespace PathonDB.Models {
    public class RowsData {
        public IList<Guid> IdList { get; set; }
        
        public Dictionary<string, object[]> Rows { get; set; }
    }
}