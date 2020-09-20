using System;
using System.Linq;

namespace PathonDB.Utils {
    public static class SelectUtils {
        public static string[] GetArgumentsFromQuery(string query) {
            return query.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }

        public static string GetFromKeywordFromArguments(string[] arguments) {
            var lowercaseArray = arguments.Select(x => x.ToLower()).ToArray();
            string charToFind = ")";

            if(arguments[1] == "*") charToFind = "*";

            return arguments[(Array.IndexOf(lowercaseArray, charToFind))];
        }
    }
}