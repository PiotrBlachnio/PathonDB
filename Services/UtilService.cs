using System;
using System.Linq;

namespace JsonDatabase.Services {
    public static class UtilService {
        public static string GetTableName(string query) {
            var arguments = query.Split(" ");
            return arguments[2];
        }

        public static string[][] GetParameters(string query) {
            var parameterString = query.Substring(0, query.Length - 2).Split("(")[1];
            var parameters = parameterString.Split(",").Select(x => x.Trim()).Select(x => x.Split(" "));

            return parameters.ToArray();
        }
    }
}