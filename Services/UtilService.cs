namespace JsonDatabase.Services {
    public static class UtilService {
        public static string GetTableName(string query) {
            var arguments = query.Split(" ");
            return arguments[1];
        }
    }
}