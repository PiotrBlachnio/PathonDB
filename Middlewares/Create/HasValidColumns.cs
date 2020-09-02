using System.Linq;
using JsonDatabase.Exceptions.Create;
using JsonDatabase.Exceptions.General;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Utils;

namespace JsonDatabase.Middlewares.Create {
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