using System;
using System.Linq;

namespace JsonDatabase.Utils {
    public static class GeneralUtils {
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

        public static bool IsTypeValid(string type, string value) {
            switch(type.ToLower()) {
                case "text":
                    if(value[0] != '"' || value[value.Length - 1] != '"') return false;
                    break;
                case "int":
                    if(!int.TryParse(value, out int i)) return false;
                    break;
                case "boolean":
                    if(value != "true" && value != "false") return false;
                    break;
            }

            return true;
        }
    }
}