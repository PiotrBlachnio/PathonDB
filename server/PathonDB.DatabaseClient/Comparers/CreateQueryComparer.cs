using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PathonDB.Comparers {
    public class CreateQueryComparer : IEqualityComparer<string[]> {
        public bool Equals(string[] firstValue, string[] secondValue) {
            return firstValue[0].ToLower() == secondValue[0].ToLower();
        }

        public int GetHashCode([DisallowNull] string[] obj) {
            return 0;
        }
    }
}