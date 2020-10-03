using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using PathonDB.DatabaseClient.Models.Database;

namespace PathonDB.Server.Services {
    public class AuthService : IAuthService {
        private readonly Dictionary<string, Client> _database = new Dictionary<string, Client>();
        
        public string GenerateNewKey() {
            return Guid.NewGuid().ToString();
        }

        public string GetKeyFromHttpContext(HttpContext httpContext) {
            httpContext.Request.Cookies.TryGetValue("access-key", out string key);
            return key;
        }

        public bool IsKeyValid(string key) {
            return Guid.TryParse(key, out Guid guid);
        }

        public Dictionary<string, Client> GetDatabase() {
            return _database;
        }
    }
}