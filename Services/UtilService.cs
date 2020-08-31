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

        public static object TransformStringValueToRealValue(string value) {
            if(value[0] == '"') {
                value.Remove(0, 1);
                value.Remove(value.Length - 1, 1);

                return value;
            } else if(value.ToLower() == "true" || value.ToLower() == "false") {
                value = value.First().ToString().ToUpper() + value.Substring(1);
                return Boolean.Parse(value);
            } else {
                return Int32.Parse(value);
            }
        }

        public static string[] GetSupportedTypes() {
            return new string[3] { "text", "int", "boolean" };
        }
    }
}