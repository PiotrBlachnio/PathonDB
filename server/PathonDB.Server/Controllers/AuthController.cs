using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PathonDB.Server.Contracts;
using PathonDB.Server.Contracts.Requests;
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
        public ActionResult UseExistingKey([FromBody] ExistingKeyRequest body) {
            if(!_authService.IsKeyValid(body.Key)) throw new Exception("Access key is invalid");

            _httpContextAccessor.HttpContext.Response.Cookies.Append("access-key", body.Key);

            return Ok();
        }

        [HttpPost(ApiRoutes.Auth.Logout)]
        public ActionResult Logout() {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("access-key");

            return Ok();
        }
    }
}