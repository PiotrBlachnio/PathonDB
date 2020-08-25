using JsonDatabase.Exceptions;

namespace JsonDatabase.Middlewares.General {
    public class QueryHasCorrectEnd : Middleware {
        private readonly string _endingString;

        public QueryHasCorrectEnd(string endingString) {
            _endingString = endingString;
        }

        public override bool Check(string query) {
            if(!query.ToUpper().EndsWith(_endingString)) throw new IncorrectQueryEndException(query);

            return this.CheckNext(query.Substring(0, query.Length - _endingString.Length));
        }
    }
}