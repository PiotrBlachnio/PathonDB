using System;
using System.Collections.Generic;

namespace JsonDatabase.Models {
    public class Column<T> {
        private readonly Dictionary<string, object> _properties;
        private readonly Dictionary<Guid, T> _data;

        public Dictionary<string, object> GetProperties() {
            return _properties;
        }
    }
}