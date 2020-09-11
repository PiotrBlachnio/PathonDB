using System;
using System.Linq;
using PathonDB.Exceptions.General;
using PathonDB.Middlewares.General;
using PathonDB.Utils;

namespace PathonDB.Middlewares.Create {
    public class HasValidColumns : Middleware {
        public override bool Check(string query) {
            var arguments = CreateUtils.GetArgumentsFromQuery(query);
            var columns = CreateUtils.GetColumnsFromArguments(arguments);

            if(!columns.All(x => x.Length == 2)) throw new MalformedColumnsException();
            
            foreach(var column in columns) {
                if(column[0].ToLower() == "id") throw new ForbiddenColumnNameException(column[0]);
            }

            return this.CheckNext(query);
        }
    }
}