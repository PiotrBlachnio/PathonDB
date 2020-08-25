using JsonDatabase.Exceptions;

namespace JsonDatabase.Middlewares.General {
    public class QueryHasCorrectEnd : Middleware {
        private readonly string _endingString;

        public QueryHasCorrectEnd(string endingString) {
            _endingString = endingString;
        }

        public override bool Check(string query) {
            if(query == null || query.Length <= _endingString.Length) throw new IncorrectQueryStartException(query);
            if(!(query.ToUpper().StartsWith(_endingString))) throw new IncorrectQueryStartException(query);

            return this.CheckNext(query.Substring(_endingString.Length));
        }
    }
}