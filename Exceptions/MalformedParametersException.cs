namespace JsonDatabase.Exceptions {
    public class MalformedParametersException : GenericException {
        public MalformedParametersException() {
            this.Message = "Query has malformed parameters";
        }
    }
}