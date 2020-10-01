using PathonDB.Exceptions.General;
using PathonDB.Middlewares.General;
using PathonDB.Utils;

namespace PathonDB.Middlewares.Select {
    public class HasValidArguments : Middleware {
        public override bool Check(string query) {
            var arguments = SelectUtils.GetArgumentsFromQuery(query);
            if(arguments[1] != "*" && !arguments[1].StartsWith("(")) throw new MalformedArgumentsException();

            var fromKeyword = SelectUtils.GetFromKeywordFromArguments(arguments).ToLower();
            if(fromKeyword != "from") throw new MalformedArgumentsException();

            var whereKeyword = SelectUtils.GetWhereKeywordFromArguments(arguments);
            if(whereKeyword != null && whereKeyword.ToLower() != "where") throw new MalformedArgumentsException();

            return this.CheckNext(query);
        }
    }
}