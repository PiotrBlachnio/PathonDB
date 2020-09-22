using PathonDB.Exceptions.General;
using PathonDB.Middlewares.General;
using PathonDB.Models;
using PathonDB.Utils;

namespace PathonDB.Middlewares.Select {
    public class HasValidCondition : Middleware {
        private readonly IDatabase _database;

        public HasValidCondition(IDatabase database) {
            _database = database;
        }

        public override bool Check(string query) {
            var arguments = SelectUtils.GetArgumentsFromQuery(query);
            var keyword = SelectUtils.GetWhereKeywordFromArguments(arguments);

            if(keyword != null && keyword.ToLower() != "where") throw new MalformedArgumentsException();

            var condition = SelectUtils.GetConditionFromArguments(arguments);
            if(keyword != null && condition == null) throw new MalformedArgumentsException();

            return CheckNext(query);
        }
    }
}