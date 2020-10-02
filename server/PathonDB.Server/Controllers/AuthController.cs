using Microsoft.AspNetCore.Mvc;
using PathonDB.Server.Contracts;

namespace PathonDB.Server.Controllers {

    [ApiController]
    public class AuthController : ControllerBase {
        [HttpGet(ApiRoutes.Auth.NewKey)]
        public ActionResult GetNewDatabaseKey() {
            return Ok("Hi");
        }
    }
}