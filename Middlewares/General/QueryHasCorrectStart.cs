using JsonDatabase.Exceptions;

namespace JsonDatabase.Middlewares.General {
    public class QueryHasCorrectStar : Middleware {
        private readonly string _startingString;

        public QueryHasCorrectStar(string startingString) {
            _startingString = startingString;
        }

        public override bool Check(string query) {
            if(query == null || query.Length <= _startingString.Length) throw new IncorrectQueryStartException(query);
            if(!(query.ToUpper().StartsWith(_startingString))) throw new IncorrectQueryStartException(query);

            return this.CheckNext(query);
        }
    }
}