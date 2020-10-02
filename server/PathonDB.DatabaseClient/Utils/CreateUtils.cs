using System;
using System.Collections.Generic;
using System.Linq;
using PathonDB.DatabaseClient.Comparers;

namespace PathonDB.DatabaseClient.Utils {
    public static class CreateUtils {
        private const string QUERY_START = "CREATE TABLE ";

        public static string[] GetArgumentsFromQuery(string query) {
            return query.Split("(").Select(x => x.Trim()).ToArray();
        }

        public static string GetTableNameFromQuery(string query) {
            var preparedQuery = string.Join(" ", query.Split(" ", StringSplitOptions.RemoveEmptyEntries));
            var substring = preparedQuery.Substring(QUERY_START.Length);
            
            return substring.Split(" ")[0].ToLower();
        }

        public static IEnumerable<string[]> GetColumnsFromArguments(string[] arguments) {
            if(arguments[1].Last() == ';') arguments[1].TrimEnd(';');
            
            return arguments[1].Split(",").Select(x => x.Trim()).Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries)).Distinct(new CreateQueryComparer());
        }
    }
}