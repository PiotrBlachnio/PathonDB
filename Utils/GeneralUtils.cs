using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PathonDB.Utils {
    public static class GeneralUtils {
        private static char[] ForbiddenChars { get; } = new char[] {
            '(',
            ')',
            '='
        };
        
        public static object TransformStringValueToRealValue(string value) {
            if(value[0] == '"') {
                return value.Trim('"');
            } else if(value.ToLower() == "true" || value.ToLower() == "false") {
                return Boolean.Parse(value);
            } else {
                return Int32.Parse(value);
            }
        }

        public static string[] GetSupportedTypes() {
            return new string[3] { "text", "int", "boolean" };
        }

        public static bool IsTypeValid(string type, string value) {
            switch(type.ToLower()) {
                case "text":
                    if(value[0] != '"' || value[value.Length - 1] != '"') return false;
                    break;
                case "int":
                    System.Diagnostics.Debug.WriteLine(int.TryParse(value, out int y));
                    if(!int.TryParse(value, out int i)) return false;
                    break;
                case "boolean":
                    if(value != "true" && value != "false") return false;
                    break;
            }

            return true;
        }

        public static bool ContainsForbiddenCharacters(string input) {
            foreach(var c in input) {
                if(ForbiddenChars.Contains(c)) return true;
            }

            return false;
        }

        public static bool ContainsOnlyAlphaNumericCharacters(string input) {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            return regexItem.IsMatch(input);
        }
    }
}