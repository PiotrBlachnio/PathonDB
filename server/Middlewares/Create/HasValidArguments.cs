using PathonDB.Exceptions.General;
using PathonDB.Middlewares.General;
using PathonDB.Utils;

namespace PathonDB.Middlewares.Create {
    public class HasValidArguments : Middleware {
        public override bool Check(string query) {
            string[] arguments = CreateUtils.GetArgumentsFromQuery(query);
            if(arguments.Length != 2) throw new MalformedArgumentsException();

            return this.CheckNext(query);
        }
    }
}