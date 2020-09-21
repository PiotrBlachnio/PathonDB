using System;
using System.Linq;

namespace PathonDB.Utils {
    public static class SelectUtils {
        private const string QUERY_START = "SELECT ";

        public static string[] GetArgumentsFromQuery(string query) {
            return query.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }

        public static string GetFromKeywordFromArguments(string[] arguments) {
            var lowercaseArray = arguments.Select(x => x.ToLower()).ToArray();
            string charToFind = arguments[1];

            if(arguments[1].StartsWith('(')) charToFind = arguments.First(x => x.EndsWith(')'));
            return arguments[(Array.IndexOf(lowercaseArray, charToFind) + 1)];
        }

        public static string GetTableNameFromArguments(string[] arguments) {
            var lowercaseArray = arguments.Select(x => x.ToLower()).ToArray();
            var tableName = arguments[Array.IndexOf(lowercaseArray, "from") + 1];

            return tableName.ToLower();
        }

        public static object GetColumnNamesFromQuery(string query) {
            var parts = query.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if(parts[1] == "*") return "*";
            
            var startIndex = query.IndexOf('(') + 1;
            var endIndex = query.IndexOf(')');

            return query.Substring(startIndex, endIndex - startIndex).Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
        }
    }
}