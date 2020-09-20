using System;
using System.Linq;

namespace PathonDB.Utils {
    public static class SelectUtils {
        public static string[] GetArgumentsFromQuery(string query) {
            return query.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }

        public static string GetFromKeywordFromArguments(string[] arguments) {
            var lowercaseArray = arguments.Select(x => x.ToLower()).ToArray();
            string charToFind = arguments[1];

            if(arguments[1].StartsWith('(')) charToFind = arguments.First(x => x.EndsWith(')'));
            return arguments[(Array.IndexOf(lowercaseArray, charToFind) + 1)];
        }
    }
}