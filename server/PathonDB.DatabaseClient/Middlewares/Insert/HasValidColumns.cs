using System.Linq;
using PathonDB.DatabaseClient.Exceptions.General;
using PathonDB.DatabaseClient.Middlewares.General;
using PathonDB.DatabaseClient.Utils;

namespace PathonDB.DatabaseClient.Middlewares.Insert {
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