using PathonDB.DatabaseClient.Exceptions.General;

namespace PathonDB.DatabaseClient.Middlewares.General {
    public class HasValidEnding : Middleware {
        private readonly string _endingString;

        public HasValidEnding(string endingString) {
            _endingString = endingString;
        }

        public override bool Check(string query) {
            query = query.TrimEnd();
            if(!query.ToUpper().EndsWith(_endingString)) throw new InvalidQueryEndingException(query);

            return this.CheckNext(query.Substring(0, query.Length - _endingString.Length));
        }
    }
}