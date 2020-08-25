using System.Collections.Generic;
using System.Linq;
using JsonDatabase.Exceptions;
using JsonDatabase.Middlewares.General;

namespace JsonDatabase.Middlewares.Create {
    public class HasValidTableName : Middleware {
        private readonly Dictionary<string, dynamic> _storage;

        public HasValidTableName(Dictionary<string, dynamic> storage) {
            _storage = storage;
        }

        public override bool Check(string query) {
            string[] arguments = query.Trim().Split("(");

            if(arguments.Length < 2 || query.StartsWith("(") || arguments[0].Equals("")) throw new InvalidTableNameException(arguments[0]);
            if(_storage.Keys.ToArray().Contains(arguments[0])) throw new TableAlreadyExistsException(arguments[0]);

            return this.CheckNext(query);
        }
    }
}