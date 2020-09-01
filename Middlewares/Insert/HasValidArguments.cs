using System.Linq;
using JsonDatabase.Exceptions;
using JsonDatabase.Exceptions.General;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Utils;

namespace JsonDatabase.Middlewares.Insert {
    public class HasValidArguments : Middleware {
        public override bool Check(string query) {
            var arguments = InsertUtils.GetArgumentsFromQuery(query);
            if(arguments.Length != 3) throw new MalformedArgumentsException();

            var valuesKeyword = InsertUtils.GetValuesKeywordFromArguments(arguments);
            if(valuesKeyword != "VALUES") throw new MalformedArgumentsException();

            return this.CheckNext(query);
        }
    }
}