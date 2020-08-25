using System.Linq;
using JsonDatabase.Exceptions;
using JsonDatabase.Middlewares.General;

namespace JsonDatabase.Middlewares.Create {
    public class HasValidParameters : Middleware {
        public override bool Check(string query) {
            var arguments = query.Split("(");

            if(arguments.Length != 2) throw new MalformedParametersException(query);
            if(!(arguments[1].Split(",").Select(x => x.Trim()).Select(x => x.Split(" ")).All(x => x.Length == 2))) throw new MalformedParametersException(query);

            return this.CheckNext(query);
        }
    }
}