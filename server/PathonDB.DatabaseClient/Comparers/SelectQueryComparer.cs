using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PathonDB.DatabaseClient.Comparers {
    public class SelectQueryComparer : IEqualityComparer<string> {
        public bool Equals(string firstValue, string secondValue) {
            return firstValue.ToLower() == secondValue.ToLower();
        }

        public int GetHashCode([DisallowNull] string obj) {
            return 0;
        }
    }
}