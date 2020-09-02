using System.Collections.Generic;
using System.Linq;

namespace JsonDatabase.Utils {
    public static class CreateUtils {
        private const string QUERY_START = "CREATE TABLE ";

        public static string[] GetArgumentsFromQuery(string query) {
            return query.Split("(").Select(x => x.Trim()).ToArray();
        }

        public static string GetTableNameFromQuery(string query) {
            var substring = query.Substring(QUERY_START.Length);

            return substring.Trim().Split(" ")[0].Trim().ToLower();
        }

        public static IEnumerable<string[]> GetColumnsFromArguments(string[] arguments) {
            return arguments[1].Split(",").Select(x => x.Trim()).Select(x => x.Split(" "));
        }    
    }
}