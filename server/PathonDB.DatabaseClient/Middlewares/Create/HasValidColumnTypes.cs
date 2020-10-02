using System;
using System.Linq;
using PathonDB.DatabaseClient.Exceptions.Create;
using PathonDB.DatabaseClient.Middlewares.General;
using PathonDB.DatabaseClient.Utils;

namespace PathonDB.DatabaseClient.Middlewares.Create {
    public class HasValidColumnTypes : Middleware {
        public override bool Check(string query) {
            var arguments = CreateUtils.GetArgumentsFromQuery(query);
            var columns = CreateUtils.GetColumnsFromArguments(arguments);

            foreach(var column in columns) {
                if(!GeneralUtils.GetSupportedTypes().Contains(column[1].ToLower())) throw new UnsupportedTypeException(column[1]);
            }
    
            return this.CheckNext(query);
        }
    }
}