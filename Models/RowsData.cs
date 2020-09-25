using System.Collections.Generic;

namespace PathonDB.Models {
    public class RowsData {
        public string[] IdList { get; set; }
        
        public Dictionary<string, object[]> Rows { get; set; }
    }
}