using System;
using System.Collections.Generic;
using System.Linq;

namespace PathonDB.Utils {
    public static class SelectUtils {
        private const string QUERY_START = "SELECT ";

        public static string[] GetArgumentsFromQuery(string query) {
            return query.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }

        public static string GetFromKeywordFromArguments(string[] arguments) {
            string charToFind = arguments[1];

            if(arguments[1].StartsWith('(')) charToFind = arguments.First(x => x.EndsWith(')'));
            return arguments[(Array.IndexOf(arguments, charToFind) + 1)];
        }

        public static string GetWhereKeywordFromArguments(string[] arguments) {
            var tableName = SelectUtils.GetTableNameFromArguments(arguments);
            var tableNameIndex = Array.IndexOf(arguments, tableName);
            
            if(tableNameIndex + 1 == arguments.Length) return null;

            return arguments[tableNameIndex + 1];
        }

        public static string GetTableNameFromArguments(string[] arguments) {
            var lowercaseArray = arguments.Select(x => x.ToLower()).ToArray();
            var tableName = arguments[Array.IndexOf(lowercaseArray, "from") + 1];

            return tableName;
        }

        public static string[] GetColumnNamesFromQuery(string query) {
            var parts = query.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if(parts[1] == "*") return new string[] { "*" };
            
            var startIndex = query.IndexOf('(') + 1;
            var endIndex = query.IndexOf(')');

            return query.Substring(startIndex, endIndex - startIndex).Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).Distinct().ToArray();
        }

        public static Dictionary<string, string> GetConditionFromArguments(string[] arguments) {
            var whereKeywordIndex = Array.IndexOf(arguments.Select(x => x.ToLower()).ToArray(), "where");
            var condition = new Dictionary<string, string>();
            
            if(whereKeywordIndex + 1 == arguments.Length) return null;

            var nextElement = arguments[whereKeywordIndex + 1];
            if(nextElement.Contains('=') && nextElement.IndexOf('=') != arguments.Length - 1) {
                var parts = nextElement.Split("=");

                condition.Add(parts[0], parts[1]);
            } else if(nextElement.Contains('=')) {
                if(whereKeywordIndex + 2 == arguments.Length) return null;

                condition.Add(nextElement.RemoveLastChar(), arguments[whereKeywordIndex + 2]);
            } else {
                // if(whereKeywordIndex + 3 == arguments.Length) return null;
                if(arguments[whereKeywordIndex + 2] == "=" && whereKeywordIndex + 3 != arguments.Length) condition.Add(nextElement, arguments[whereKeywordIndex + 3]);
                else if(arguments[whereKeywordIndex + 2].StartsWith("=") && whereKeywordIndex + 3 == arguments.Length) condition.Add(nextElement, arguments[whereKeywordIndex + 2].Remove(0));
                else return null;
            }

            return condition;
        }
    }
}