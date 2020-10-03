using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PathonDB.DatabaseClient.Models.Database;
using PathonDB.Server.Contracts;
using PathonDB.Server.Contracts.Requests;
using PathonDB.Server.Contracts.Responses;
using PathonDB.Server.Models;
using PathonDB.Server.Services;

namespace PathonDB.Server.Controllers {

    [ApiController]
    public class DatabaseController : ControllerBase {
        private readonly IDatabaseClient _databaseClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthService _authService;

        public DatabaseController(IHttpContextAccessor httpContextAccessor, IAuthService authService, IDatabaseClient databaseClient) {
            _databaseClient = databaseClient;
            _httpContextAccessor = httpContextAccessor;
            _authService = authService;
        }
        
        [HttpPost(ApiRoutes.Database.Query)]
        public ActionResult PerformQuery([FromBody] QueryRequest body) {
            var key = _authService.GetKeyFromHttpContext(_httpContextAccessor.HttpContext);

            if(!_databaseClient.ContainsKey(key)) _databaseClient.AddClient(key);

            var result = _databaseClient.PerformQuery(key, body.Query);
            var response = new QueryResponse() { Result = result };
            
            return Ok(response);
        }
    }
}