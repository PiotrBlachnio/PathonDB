using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PathonDB.Server.Services;

namespace PathonDB.Server.Middlewares {
    public class AuthMiddleware {
        private readonly RequestDelegate _next;
        private readonly ILogger<AuthMiddleware> _logger;
        private readonly IAuthService _authService = new AuthService();

        public AuthMiddleware(RequestDelegate next, ILogger<AuthMiddleware> logger) {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context) {
            var key = _authService.GetKeyFromHttpContext(context);
            _logger.LogInformation(key);
            if(!_authService.IsKeyValid(key)) throw new Exception("Access key is invalid");
            
            _logger.LogInformation("Access key has passed authentication process successfully");
            await _next(context);
        }
    }
}