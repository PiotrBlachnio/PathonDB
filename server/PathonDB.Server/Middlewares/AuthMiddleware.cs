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
            var key = GetKeyFromCookies(context);
            if(!IsKeyValid(key)) throw new Exception("Access key is invalid");
            
            _logger.LogInformation("Access key has passed authentication process successfully");
            await _next(context);
        }

        private string GetKeyFromCookies(HttpContext context) {
            context.Request.Cookies.TryGetValue("access-key", out string cookie);
            return cookie;
        }

        private bool IsKeyValid(string key) {
            return Guid.TryParse(key, out Guid guid);
        }
    }
}