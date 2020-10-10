using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PathonDB.Server.Contracts;
using PathonDB.Server.Contracts.Requests;
using PathonDB.Server.Contracts.Responses;
using PathonDB.Server.Models;
using PathonDB.Server.Services;

namespace PathonDB.Server.Controllers {

    [ApiController]
    public class AuthController : ControllerBase {
        private readonly IDatabaseClient _databaseClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthService _authService;

        public AuthController(IHttpContextAccessor httpContextAccessor, IAuthService authService, IDatabaseClient databaseClient) {
            _databaseClient = databaseClient;
            _httpContextAccessor = httpContextAccessor;
            _authService = authService;
        }

        [HttpPost(ApiRoutes.Auth.Authorize)]
        public ActionResult Authorize([FromBody] ExistingKeyRequest body) {
            var key = body.Key;

            if(!_authService.IsKeyValid(key)) throw new Exception("Access key is invalid");

            if(!_databaseClient.ContainsKey(key)) _databaseClient.AddClient(key);

            return Ok();
        }
    }
}