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
    }
}