using System.Collections.Generic;
using System.Linq;

namespace JsonDatabase.Utils {
    public static class CreateUtils {
        public static IEnumerable<string[]> GetColumnsFromQuery(string columnString) {
            return columnString.Split(",").Select(x => x.Trim()).Select(x => x.Split(" "));
        }
    }
}