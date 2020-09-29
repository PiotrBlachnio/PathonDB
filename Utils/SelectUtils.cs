using System;
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
            
            if(tableNameIndex + 1 == arguments.Length || arguments[tableNameIndex + 1].Trim() == ";") return null;

            return arguments[tableNameIndex + 1];
        }

        public static string GetTableNameFromArguments(string[] arguments) {
            var lowercaseArray = arguments.Select(x => x.ToLower()).ToArray();
            var fromIndex = Array.IndexOf(lowercaseArray, "from");

            if(fromIndex == arguments.Length - 1) return null;
            var tableName = arguments[fromIndex + 1];

            return tableName;
        }

        public static string[] GetColumnNamesFromQuery(string query) {
            var parts = query.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if(parts[1] == "*") return new string[] { "*" };
            
            var startIndex = query.IndexOf('(') + 1;
            var endIndex = query.IndexOf(')');

            return query.Substring(startIndex, endIndex - startIndex).Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).Distinct().ToArray();
        }

        public static string[] GetConditionFromQuery(string query) {
            if(query.IndexOf("=") == -1) return null;

            var whereKeywordIndex = query.ToLower().IndexOf("where");
            var substring = query.Substring(whereKeywordIndex + 5);
            var condition = new string[2];

            var arguments = substring.Split("=").Select(x => x.Trim()).ToArray();
            var argumentsLength = arguments.Length;

            var columnName = arguments[argumentsLength - 2];
            var value = arguments[argumentsLength - 1].TrimEnd(';').Trim();

            if(columnName == "" || value == "") return null;

            condition[0] = columnName;
            condition[1] = value;
            
            return condition;
        }
    }
}