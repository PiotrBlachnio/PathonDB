using System;
using System.Collections.Generic;

namespace JsonDatabase.Models {
    public class Column<T> {
        private Dictionary<string, object> properties { get; set; }
        private Dictionary<Guid, T> data { get; set; }
    }
}