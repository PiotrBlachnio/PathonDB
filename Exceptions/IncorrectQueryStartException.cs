namespace JsonDatabase.Exceptions {
    public class IncorrectQueryStartException : GenericException {
        public IncorrectQueryStartException(string query) {
            this.Message = $"Incorrect start of query: {query}";
        }
    }
}