using System.Linq;
using JsonDatabase.Exceptions;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Utils;

namespace JsonDatabase.Middlewares.Create {
    public class HasValidParameters : Middleware {
        public override bool Check(string query) {
            var arguments = query.Split("(");
            if(arguments.Length != 2) throw new MalformedParametersException();

            var columns = CreateUtils.GetColumnsFromQuery(arguments[1]);
            if(!columns.All(x => x.Length == 2)) throw new MalformedParametersException();
            
            foreach(var column in columns) {
                if(column[0].ToLower() == "id") throw new ForbiddenColumnNameException(column[0]);
            }

            return this.CheckNext(query);
        }
    }
}