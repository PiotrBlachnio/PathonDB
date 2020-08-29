using System.Linq;
using JsonDatabase.Exceptions;
using JsonDatabase.Middlewares.General;

namespace JsonDatabase.Middlewares.Create {
    public class HasValidParameters : Middleware {
        public override bool Check(string query) {
            var arguments = query.Split("(");
            var columns = arguments[1].Split(",").Select(x => x.Trim()).Select(x => x.Split(" "));

            if(arguments.Length != 2) throw new MalformedParametersException();
            if(!columns.All(x => x.Length == 2)) throw new MalformedParametersException();
            
            foreach(var column in columns) {
                if(column[0].ToLower() == "id") throw new ForbiddenColumnNameException(column[0]);
            }

            return this.CheckNext(query);
        }
    }
}