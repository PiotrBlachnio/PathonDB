using System;

namespace PathonDB.Server.Services {
    public class AuthService : IAuthService {
        public string GenerateNewKey() {
            return Guid.NewGuid().ToString();
        }
    }
}