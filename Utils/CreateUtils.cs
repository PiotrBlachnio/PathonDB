using System.Collections.Generic;
using System.Linq;

namespace JsonDatabase.Utils {
    public static class CreateUtils {
        public static IEnumerable<string[]> GetColumnsFromQuery(string columnString) {
            return columnString.Split(",").Select(x => x.Trim()).Select(x => x.Split(" "));
        }

        public static string[] GetArgumentsFromQuery(string query) {
            return query.Split("(").Select(x => x.Trim()).ToArray();
        }

        public static string GetTableNameFromQuery(string query) {
            var queryStart = "CREATE TABLE ";
            var substring = query.Substring(queryStart.Length);

            return substring.Trim().Split(" ")[0].Trim();
        }
    }
}

//? CREATE TABLE    users  (email text, phoneNumber int, isAdult boolean);