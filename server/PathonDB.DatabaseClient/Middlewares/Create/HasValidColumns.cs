using System.Linq;
using PathonDB.DatabaseClient.Exceptions.General;
using PathonDB.DatabaseClient.Middlewares.General;
using PathonDB.DatabaseClient.Utils;

namespace PathonDB.DatabaseClient.Middlewares.Create {
    public class HasValidColumns : Middleware {
        public override bool Check(string query) {
            var arguments = CreateUtils.GetArgumentsFromQuery(query);
            var columns = CreateUtils.GetColumnsFromArguments(arguments);

            if(!columns.All(x => x.Length == 2)) throw new MalformedColumnsException();
            
            foreach(var column in columns) {
                if(!GeneralUtils.ContainsOnlyAlphaNumericCharacters(column[0])) throw new ForbiddenCharactersException(column[0]);
                if(column[0].ToLower() == "id") throw new ForbiddenColumnNameException(column[0]);
            }

            return this.CheckNext(query);
        }
    }
}