using PathonDB.DatabaseClient.Exceptions.General;
using PathonDB.DatabaseClient.Middlewares.General;
using PathonDB.DatabaseClient.Utils;

namespace PathonDB.DatabaseClient.Middlewares.Create {
    public class HasValidArguments : Middleware {
        public override bool Check(string query) {
            string[] arguments = CreateUtils.GetArgumentsFromQuery(query);
            if(arguments.Length != 2) throw new MalformedArgumentsException();

            return this.CheckNext(query);
        }
    }
}