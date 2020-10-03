using Microsoft.AspNetCore.Http;

namespace PathonDB.Server.Services {
    public interface IAuthService {
        string GenerateNewKey();

        string GetKeyFromHttpContext(HttpContext httpContext);

        bool IsKeyValid(string key);
    }
}