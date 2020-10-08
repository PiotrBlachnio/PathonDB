using System;
using Microsoft.AspNetCore.Http;

namespace PathonDB.Server.Services {
    public class AuthService : IAuthService {
        public string GenerateNewKey() {
            return Guid.NewGuid().ToString();
        }

        public string GetKeyFromHttpContext(HttpContext httpContext) {
            var key = httpContext.Request.Headers["access-key"];
            return key;
        }

        public bool IsKeyValid(string key) {
            return Guid.TryParse(key, out Guid guid);
        }
    }
}