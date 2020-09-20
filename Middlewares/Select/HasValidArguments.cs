using PathonDB.Exceptions.General;
using PathonDB.Middlewares.General;
using PathonDB.Utils;

namespace PathonDB.Middlewares.Select {
    public class HasValidArguments : Middleware {
        public override bool Check(string query) {
            var arguments = SelectUtils.GetArgumentsFromQuery(query);
            if(arguments[1] != "*" && !arguments[1].StartsWith("(")) throw new MalformedArgumentsException();

            var keyword = SelectUtils.GetFromKeywordFromArguments(arguments).ToLower();
            if(keyword != "from") throw new MalformedArgumentsException();

            return this.CheckNext(query);
        }
    }
}