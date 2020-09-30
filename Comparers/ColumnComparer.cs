using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PathonDB.Comparers {
    public class ColumnComparer : IEqualityComparer<string[]> {
        public bool Equals(string[] firstColumn, string[] secondColumn) {
            return firstColumn[0].ToLower() == secondColumn[0].ToLower();
        }

        public int GetHashCode([DisallowNull] string[] obj) {
            return 0;
        }
    }
}