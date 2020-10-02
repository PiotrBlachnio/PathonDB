using System;

namespace PathonDB.Server.Services {
    public class AuthService : IAuthService {
        public string GenerateDatabaseKey() {
            return Guid.NewGuid().ToString();
        }
    }
}