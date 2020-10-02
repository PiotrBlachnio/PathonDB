using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PathonDB.Server.Contracts;
using PathonDB.Server.Contracts.Responses;
using PathonDB.Server.Services;

namespace PathonDB.Server.Controllers {

    [ApiController]
    public class AuthController : ControllerBase {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthService _authService;

        public AuthController(IHttpContextAccessor httpContextAccessor, IAuthService authService) {
            _httpContextAccessor = httpContextAccessor;
            _authService = authService;
        }

        [HttpGet(ApiRoutes.Auth.NewKey)]
        public ActionResult GetNewKey() {
            var key = _authService.GenerateNewKey();
            var response = new NewKeyResponse() { Key = key };

            return Ok(response);
        }

        [HttpPost(ApiRoutes.Auth.ExistingKey)]
        public ActionResult UseExistingKey() {
            var key = _authService.GetKeyFromHttpContext(_httpContextAccessor.HttpContext);

            if(!_authService.IsKeyValid(key)) throw new Exception("Access key is invalid");
        }
    }
}