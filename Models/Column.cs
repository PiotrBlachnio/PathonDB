using System;
using System.Collections.Generic;

namespace JsonDatabase.Models {
    public class Column {
        private readonly Properties _properties;
        private readonly Dictionary<Guid, object> _data = new Dictionary<Guid, object>();

        public Column(Properties properties) {
            _properties = properties;
        }  

        public Properties GetProperties() {
            return _properties;
        }
    }
}