using System.Collections.Generic;
using System.Linq;

namespace JsonDatabase.Utils {
    public static class InsertUtils {
        public static string[] GetArgumentsFromQuery(string query) {
            return query.Split("(").Select(x => x.Trim()).ToArray();
        }

        public static string GetTableNameFromQuery(string query) {
            var queryStart = "INSERT INTO ";
            var substring = query.Substring(queryStart.Length);

            return substring.Trim().Split(" ")[0].Trim().ToLower();
        }

        public static string GetValuesKeywordFromArguments(string[] arguments) {
            return arguments[1].Split(")")[1].Trim().ToUpper();
        }

        public static IEnumerable<string> GetColumnsFromArguments(string[] arguments) {
            return arguments[1].Split(")")[0].Split(",").Select(x => x.Trim());
        }

        public static IEnumerable<string> GetValuesFromArguments(string[] arguments) {
            return arguments[2].Split(",").Select(x => x.Trim());
        }
    }
}