using Microsoft.AspNetCore.Mvc;
using PathonDB.Server.Contracts;

namespace PathonDB.Server.Controllers {

    [ApiController]
    public class DatabaseController : ControllerBase {
        [HttpPost(ApiRoutes.Database.Query)]
        public ActionResult PerformQuery() {
            return Ok("Database controller");
        }
    }
}