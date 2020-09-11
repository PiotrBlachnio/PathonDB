using System;
using System.Collections.Generic;
using System.Linq;

namespace PathonDB.Utils {
    public static class InsertUtils {
        private const string QUERY_START = "INSERT INTO ";

        public static string[] GetArgumentsFromQuery(string query) {
            return query.Split("(").Select(x => x.Trim()).ToArray();
        }

        public static string GetTableNameFromQuery(string query) {
            var substring = query.Substring(QUERY_START.Length);

            return substring.Trim().Split(" ")[0].Trim().ToLower();
        }

        public static string GetValuesKeywordFromArguments(string[] arguments) {
            return arguments[1].Split(")")[1].Trim().ToUpper();
        }

        public static IEnumerable<string> GetColumnsFromArguments(string[] arguments) {
            return arguments[1].Split(")")[0].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim());
        }

        public static IEnumerable<string> GetValuesFromArguments(string[] arguments) {
            return arguments[2].Split(",").Select(x => x.Trim());
        }
    }
}