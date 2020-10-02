namespace PathonDB.Server.Contracts {
    public static class ApiRoutes {
        private const string Root = "api";

        private const string Version = "v1";

        private const string Base = Root + "/" + Version;

        public static class Auth {
            public const string NewKey = Base + "/new-key";

            public const string ExistingKey = Base + "existing-key";
        }
    }
}