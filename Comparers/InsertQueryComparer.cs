using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PathonDB.Comparers {
    public class InsertQueryComparer : IEqualityComparer<string> {
        public bool Equals(string firstValue, string secondValue) {
            return firstValue.ToLower() == secondValue.ToLower();
        }

        public int GetHashCode([DisallowNull] string obj) {
            return 0;
        }
    }
}