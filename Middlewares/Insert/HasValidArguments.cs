using System.Linq;
using JsonDatabase.Exceptions;
using JsonDatabase.Middlewares.General;

namespace JsonDatabase.Middlewares.Insert {
    public class HasValidArguments : Middleware {
        public override bool Check(string query) {
            var arguments = query.Split("(");
            if(arguments.Length != 3) throw new MalformedParametersException();

            var valuesKeyword = arguments[1].Split(")")[1].Trim();
            if(valuesKeyword.ToUpper() != "VALUES") throw new InvalidQueryArgumentsException(valuesKeyword);

            return this.CheckNext(query);
        }
    }
}