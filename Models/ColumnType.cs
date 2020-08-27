using System.Linq;

namespace JsonDatabase.Models {
    public static class ColumnType {
        public const string INT = "INT";
        public const string TEXT = "TEXT";
        public const string BOOLEAN = "BOOLEAN";

        public static bool IsFieldAllowed(string field) {
            var fields = typeof(ColumnType).GetFields();
            return fields.Any(x => x.Name == field.ToUpper());
        }
    }
}