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

        [Theory]
        [InlineData("SELECT * FROM users WHERE id = 50;")]
        [InlineData("  SELECT   *   FROM    users   WHERE   id    =    50;")]
        [InlineData("SELECT (   username   ,   email   )      FROM   users  WHERE id=50;   ")]
        public void GetWhereKeywordFromArguments_KeywordExists_ShouldReturnValidKeyword(string query) {
            var arguments = SelectUtils.GetArgumentsFromQuery(query);

            var actual = SelectUtils.GetWhereKeywordFromArguments(arguments);

            var expected = "WHERE";

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("SELECT * FROM users;")]
        [InlineData("  SELECT   *   FROM     users   ;   ")]
        [InlineData("SELECT (   username   ,   email   )      FROM   users  ;   ")]
        public void GetWhereKeywordFromArguments_KeywordNotExists_ShouldReturnNull(string query) {
            var arguments = SelectUtils.GetArgumentsFromQuery(query);

            var actual = SelectUtils.GetWhereKeywordFromArguments(arguments);

            Assert.Null(actual);
        }

        [Theory]
        [InlineData("SELECT * FROM users ;")]
        [InlineData("  SELECT   *   FROM     users   ;   ")]
        [InlineData("SELECT (   username   ,   email   )      FROM   users  ;   ")]
        [InlineData("  SELECT   *   FROM    users   WHERE   id    =    50;")]
        [InlineData("SELECT (   username   ,   email   )      FROM   users  WHERE id=50;   ")]
        public void GetTableNameFromArguments_ShouldReturnValidTableName(string query) {
            var arguments = SelectUtils.GetArgumentsFromQuery(query);

            var actual = SelectUtils.GetTableNameFromArguments(arguments);

            var expected = "users";

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("SELECT * FROM users ;")]
        [InlineData("  SELECT   *   FROM     users   ;   ")]
        public void GetColumnNamesFromQuery_AsteriksSymbol_ShouldReturnValidColumnNamesArray(string query) {
            var actual = SelectUtils.GetColumnNamesFromQuery(query);

            var expected = new string[] { "*" };

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("SELECT (email, isAdult) FROM users ;")]
        [InlineData("  SELECT   (email, isAdult)   FROM     users   ;   ")]
        [InlineData("  SELECT   (   email   ,   isAdult   )   FROM     users   ;   ")]
        public void GetColumnNamesFromQuery_MultipleColumnNames_ShouldReturnValidColumnNamesArray(string query) {
            var actual = SelectUtils.GetColumnNamesFromQuery(query);

            var expected = new string[] { "email", "isAdult" };

            Assert.Equal(expected, actual);
        }
    }
}