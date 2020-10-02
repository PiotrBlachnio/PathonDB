using PathonDB.DatabaseClient.Exceptions.General;
using PathonDB.DatabaseClient.Middlewares.General;
using PathonDB.DatabaseClient.Utils;

namespace PathonDB.DatabaseClient.Middlewares.Select {
    public class HasValidCondition : Middleware {
        public override bool Check(string query) {
            var arguments = SelectUtils.GetArgumentsFromQuery(query);
            var keyword = SelectUtils.GetWhereKeywordFromArguments(arguments);

            var condition = SelectUtils.GetConditionFromQuery(query);
            var tableName = SelectUtils.GetTableNameFromArguments(arguments).ToLower();

            if(keyword != null && condition == null) throw new MalformedArgumentsException();
            return CheckNext(query);
        }
    }
}