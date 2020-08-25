using System;
using System.Collections.Generic;
using JsonDatabase.Middlewares.General;

namespace JsonDatabase.Middlewares.Create {
    public class HasValidTableName : Middleware {
        private readonly Dictionary<string, dynamic> _storage;

        public HasValidTableName(Dictionary<string, dynamic> storage) {
            _storage = storage;
        }

        public override bool Check(string query) {
            string[] arguments = query.Trim().Split("(");

            Console.WriteLine("Fired");
            foreach(var argument in arguments) Console.WriteLine(argument);

            return this.CheckNext(query);
        }
    }
}