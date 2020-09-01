namespace JsonDatabase.Utils {
    public static class InsertUtils {
        public static string GetTableNameFromQuery(string query) {
            var queryStart = "INSERT INTO ";
            var substring = query.Substring(queryStart.Length);

            return substring.Trim().Split(" ")[0].Trim().ToLower();
        }
    }
}