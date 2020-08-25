using System;
using System.Linq;
using JsonDatabase.Exceptions;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Models;

namespace JsonDatabase.Middlewares.Create {
    public class HasValidSupportedParameters : Middleware {
        public override bool Check(string query) {
            var arguments = query.Split("(");
            if(arguments.Length < 2) throw new MalformedParametersException();
            var parameters = arguments[1].Split(",").Select(x => x.Trim()).Select(x => x.Split(" "));

            foreach(var field in parameters) {
                Console.WriteLine(field[1]);
            }
            // foreach(var param in parameters) Console.WriteLine(param);
            // ColumnType.IsFieldAllowed("");
            
            return this.CheckNext(query);
        }
    }
}