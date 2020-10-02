using PathonDB.DatabaseClient.Exceptions.General;
using PathonDB.DatabaseClient.Middlewares.General;
using PathonDB.DatabaseClient.Utils;

namespace PathonDB.DatabaseClient.Middlewares.Insert {
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