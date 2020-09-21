using PathonDB.Models;
using PathonDB.Validators;

namespace PathonDB.Services {
    public class SelectService : Service {
        public SelectService(IDatabase database) : base(database) {}

        public override void PerformQuery(string query) {
            new SelectValidator(this._database).Validate(query);
        }
    }
}