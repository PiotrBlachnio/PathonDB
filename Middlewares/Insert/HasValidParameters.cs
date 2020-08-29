using System.Linq;
using JsonDatabase.Exceptions;
using JsonDatabase.Middlewares.General;

namespace JsonDatabase.Middlewares.Insert {
    public class HasValidParameters : Middleware {
        public override bool Check(string query) {
            var arguments = query.Split("(");
            if(arguments.Length != 2) throw new MalformedParametersException();

            var values = arguments[1].Split(",").Select(x => x.Trim()).Select(x => x.Split(" "));
            if(!values.All(x => x.Length == 1)) throw new MalformedParametersException();
            
            return this.CheckNext(query);
        }
    }
}