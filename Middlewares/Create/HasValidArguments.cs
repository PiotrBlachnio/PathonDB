using JsonDatabase.Exceptions.General;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Utils;

namespace JsonDatabase.Middlewares.Create {
    public class HasValidArguments : Middleware {
        public override bool Check(string query) {
            string[] arguments = CreateUtils.GetArgumentsFromQuery(query);
            if(arguments.Length != 2) throw new MalformedArgumentsException();

            return this.CheckNext(query);
        }
    }
}