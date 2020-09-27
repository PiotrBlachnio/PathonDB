using PathonDB.Utils;
using Xunit;

namespace PathonDB.Tests.Utils {
    public class SelectUtilsTests {
        [Theory]
        [InlineData("SELECT * FROM users WHERE id = 50;")]
        [InlineData("  SELECT   *   FROM    users   WHERE   id    =    50;")]
        public void GetArgumentsFromQuery_ShouldReturnValidStringArray(string query) {
            var actual = SelectUtils.GetArgumentsFromQuery(query);

            var expected = new string[] { "SELECT", "*", "FROM", "users", "WHERE", "id", "=", "50;" };

            Assert.Equal(expected, actual);
        }
    }
}