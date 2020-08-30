using System.Linq;
using JsonDatabase.Exceptions;
using JsonDatabase.Middlewares.General;

namespace JsonDatabase.Middlewares.Insert {
    public class HasValidParameters : Middleware {
        public override bool Check(string query) {
            var arguments = query.Split("(");
            if(arguments.Length != 3) throw new MalformedParametersException();

            var columnNames = arguments[1].Split(")")[0].Split(",").Select(x => x.Trim()).Select(x => x.Split(" "));
            var values = arguments[2].Split(",").Select(x => x.Trim()).Select(x => x.Split(" "));
            
            if(!columnNames.All(x => x.Length == 1)) throw new MalformedParametersException();
            if(!values.All(x => x.Length == 1)) throw new MalformedParametersException();

            if(columnNames.Count() != values.Count()) 
            
            return this.CheckNext(query);
        }
    }
}

// users | username, email) VALUES 