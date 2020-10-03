using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PathonDB.DatabaseClient.Models.Database;
using PathonDB.Server.Contracts;
using PathonDB.Server.Contracts.Requests;
using PathonDB.Server.Contracts.Responses;
using PathonDB.Server.Services;

namespace PathonDB.Server.Controllers {

    [ApiController]
    public class DatabaseController : ControllerBase {
        private readonly Dictionary<string, Client> _database = new Dictionary<string, Client>() ;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthService _authService;

        public DatabaseController(IHttpContextAccessor httpContextAccessor, IAuthService authService) {
            _httpContextAccessor = httpContextAccessor;
            _authService = authService;
        }
        
        [HttpPost(ApiRoutes.Database.Query)]
        public ActionResult PerformQuery([FromBody] QueryRequest body) {
            var key = _authService.GetKeyFromHttpContext(_httpContextAccessor.HttpContext);

            if(!_database.ContainsKey(key)) _database.Add(key, new Client());

            var result = _database[key].ExecuteQuery(new string[] { null });
            var response = new QueryResponse() { Result = result };
            
            return Ok(response);
        }
    }
}