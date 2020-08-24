using System.Collections.Generic;

namespace JsonDatabase.Database {
    public class ResultSet {
        public bool isSuccess { get; set; }

        public List<dynamic> data { get; set; } = null;
    }
}