using JsonDatabase.Exceptions.General;

namespace JsonDatabase.Middlewares.General {
    public class HasCorrectEnding : Middleware {
        private readonly string _endingString;

        public HasCorrectEnding(string endingString) {
            _endingString = endingString;
        }

        public override bool Check(string query) {
            if(!query.ToUpper().EndsWith(_endingString)) throw new InvalidQueryEndingException(query);

            return this.CheckNext(query.Substring(0, query.Length - _endingString.Length));
        }
    }
}