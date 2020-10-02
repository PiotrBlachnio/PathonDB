using Newtonsoft.Json;

namespace PathonDB.Server.Exceptions {
    public class ExceptionDetails {
        public string Message { get; set; }

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}