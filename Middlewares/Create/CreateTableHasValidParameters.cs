using System.Linq;
using JsonDatabase.Exceptions;

namespace JsonDatabase.Middlewares.Create {
    public class CreateTableHasValidParameters : Middleware {
        public override bool Check(string query) {
            var arguments = query.Split("(");

            if(arguments.Length != 2) throw new MalformedParametersException();
            if(!(arguments[1].Split(",").Select(x => x.Trim()).Select(x => x.Split(" ")).All(x => x.Length == 2))) throw new MalformedParametersException();

            return this.CheckNext(query);
        }
    }
}