using System;
using System.Linq;
using JsonDatabase.Exceptions;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Utils;

namespace JsonDatabase.Middlewares.Create {
    public class HasValidSupportedTypes : Middleware {
        public override bool Check(string query) {
            var arguments = query.Split("(");
            if(arguments.Length < 2) throw new MalformedParametersException();
            var parameters = arguments[1].Split(",").Select(x => x.Trim()).Select(x => x.Split(" "));

            foreach(var field in parameters) {
                if(!GeneralUtils.GetSupportedTypes().Contains(field[1].ToLower())) throw new UnsupportedTypeException(field[1]);
            }
    
            return this.CheckNext(query);
        }
    }
}