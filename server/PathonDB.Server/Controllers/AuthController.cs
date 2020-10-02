using Microsoft.AspNetCore.Mvc;
using PathonDB.Server.Contracts;
using PathonDB.Server.Contracts.Responses;
using PathonDB.Server.Services;

namespace PathonDB.Server.Controllers {

    [ApiController]
    public class AuthController : ControllerBase {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) {
            _authService = authService;
        }

        [HttpGet(ApiRoutes.Auth.NewKey)]
        public ActionResult GetNewKey() {
            var key = _authService.GenerateNewKey();
            var response = new NewKeyResponse() { Key = key };

            return Ok(response);
        }
    }
}