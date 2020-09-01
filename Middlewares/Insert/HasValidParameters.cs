using System.Linq;
using JsonDatabase.Exceptions.General;
using JsonDatabase.Middlewares.General;
using JsonDatabase.Utils;

namespace JsonDatabase.Middlewares.Insert {
    public class HasValidParameters : Middleware {
        public override bool Check(string query) {
            var arguments = InsertUtils.GetArgumentsFromQuery(query);
            
            var columnNames = InsertUtils.GetColumnNamesFromArguments(arguments);
            var values = InsertUtils.GetValuesFromArguments(arguments);
            
            if(!columnNames.All(x => x.Length == 1)) throw new MalformedColumnsException();
            if(!values.All(x => x.Length == 1)) throw new MalformedColumnsException();

            if(columnNames.Count() != values.Count()) throw new MalformedColumnsException();
            
            return this.CheckNext(query);
        }
    }
}