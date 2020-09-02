using System;
using System.Linq;
using JsonDatabase.Exceptions.General;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Utils;

namespace JsonDatabase.Middlewares.Insert {
    public class HasValidColumns : Middleware {
        public override bool Check(string query) {
            var arguments = InsertUtils.GetArgumentsFromQuery(query);
            
            var columns = InsertUtils.GetColumnsFromArguments(arguments);
            var values = InsertUtils.GetValuesFromArguments(arguments);
            
            if(columns.Count() != values.Count()) throw new MalformedColumnsException();
            
            return this.CheckNext(query);
        }
    }
}