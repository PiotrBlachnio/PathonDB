using System.Collections.Generic;
using System.Linq;

namespace PathonDB.Models {
    public class Database : IDatabase {
        private readonly Dictionary<string, ITable> _tables = new Dictionary<string, ITable>();

        public string[] GetTableNames() {
            return _tables.Keys.ToArray();
        }
        
        public ITable GetTable(string tableName) {
            return _tables[tableName];
        }

        public void AddTable(ITable table) {
            _tables.Add(table.Name, table);
        }
    }
}

/**
    {
        "users": {
            "username": {
                properties: {
                    notNull: true
                },
                data: {
                    1: "Jeff123",
                    2: "Bob431"
                }
            },
            "email": {
                properties: {
                    notNul: false
                },
                data: {
                    1: "Jeff@gmail.com",
                    2: "Bob@gmail.com"
                } 
            }
        }
    }

    SELECT * FROM users;

    {
        "id": [1, 2]
        "username": ["Jeff123", "Bob431"],
        "email": ["Jeff@gmail.com", "Bob@gmail.com"]
    }

    SELECT * FROM users WHERE id = 2;
    {
        "id": [2]
        "username": ["Bob431"],
        "email": ["Bob@gmail.com"]
    }

    SELECT * FROM users WHERE username = Jeff123;
    {
        "id": [1]
        "username": ["Jeff123"],
        "email": ["Jeff@gmail.com"]
    }
*/