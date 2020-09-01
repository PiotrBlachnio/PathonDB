using System;
using System.Linq;
using JsonDatabase.Exceptions;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Utils;

namespace JsonDatabase.Middlewares.Create {
    public class HasValidColumnTypes : Middleware {
        public override bool Check(string query) {
            var arguments = query.Split("(");
            var columns = CreateUtils.GetColumnsFromQuery(arguments[1]);

            foreach(var column in columns) {
                if(!GeneralUtils.GetSupportedTypes().Contains(column[1].ToLower())) throw new UnsupportedTypeException(column[1]);
            }
    
            return this.CheckNext(query);
        }
    }
}