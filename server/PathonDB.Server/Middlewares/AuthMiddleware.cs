using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace PathonDB.Server.Middlewares {
    public class AuthMiddleware {
        private readonly RequestDelegate _next;
        private readonly ILogger<AuthMiddleware> _logger;

        public AuthMiddleware(RequestDelegate next, ILogger<AuthMiddleware> logger) {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context) {
            var databaseKey = GetCookie(context, "database-key");
            if(!IsDatabaseKeyValid(databaseKey)) throw new Exception("Database key is invalid");
            
            _logger.LogInformation("Database key has passed authentication process successfully");
            await _next(context);
        }

        private string GetCookie(HttpContext context, string cookieName) {
            context.Request.Cookies.TryGetValue("database-key", out string cookie);
            return cookie;
        }

        private bool IsDatabaseKeyValid(string databaseKey) {
            return Guid.TryParse(databaseKey, out Guid guid);
        }
    }
}