using System.Collections.Generic;
using System.Linq;

namespace JsonDatabase.Models {
    public class Database {
        private readonly Dictionary<string, Table> _tables = new Dictionary<string, Table>();

        public string[] GetTableNames() {
            return _tables.Keys.ToArray();
        }
        
        public Table GetTable(string tableName) {
            return _tables[tableName];
        }

        public void AddTable(Table table) {
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