using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using PathonDB.DatabaseClient.Models.Database;

namespace PathonDB.Server.Services {
    public interface IAuthService {
        string GenerateNewKey();

        string GetKeyFromHttpContext(HttpContext httpContext);

        bool IsKeyValid(string key);

        Dictionary<string, Client> GetDatabase();
    }
}