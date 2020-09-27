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

        [Theory]
        [InlineData("SELECT * FROM users WHERE id = 50;")]
        [InlineData("SELECT (username, email) FROM users;")]
        [InlineData("SELECT (   username   ,   email   )      FROM   users  ;   ")]
        [InlineData("  SELECT   *   FROM    users   WHERE   id    =    50;")]
        public void GetFromKeywordFromArguments_ShouldReturnValidKeyword(string query) {
            var arguments = SelectUtils.GetArgumentsFromQuery(query);

            var actual = SelectUtils.GetFromKeywordFromArguments(arguments);

            var expected = "FROM";

            Assert.Equal(expected, actual);
        }
    }
}