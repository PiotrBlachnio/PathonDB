using PathonDB.Utils;
using Xunit;

namespace PathonDB.Tests.Utils {
    public class CreateUtilsTests {
        [Theory]
        [InlineData("CREATE TABLE users (email text, phoneNumber int);")]
        [InlineData("CREATE TABLE users   (  email text, phoneNumber int);")]
        public void GetArgumentsFromQuery_ShouldReturnValidStringArray(string query) {
            var actual = CreateUtils.GetArgumentsFromQuery(query);

            var expected = new string[] { "CREATE TABLE users",  "email text, phoneNumber int);" };

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("CREATE TABLE users (email text, phoneNumber int);", "users")]
        [InlineData("CREATE TABLE   users (email text, phoneNumber int);", "users")]
        [InlineData("CREATE TABLE users    (email text, phoneNumber int);", "users")]
        [InlineData("CREATE TABLE     users    (email text, phoneNumber int);", "users" )]
        [InlineData("CREATE TABLE     ItemS    (email text, phoneNumber int);", "items" )]
        [InlineData("CREATE TABLE  ITEMS    (email text, phoneNumber int);", "items" )]
        public void GetTableNameFromQuery_ShouldReturnValidTableName(string query, string expectedTableName) {
            var actual = CreateUtils.GetTableNameFromQuery(query);

            Assert.Equal(actual, expectedTableName);
        }

        [Fact]
        public void GetColumnsFromArguments_ShouldReturnValidColumns() {
            var query = "CREATE TABLE users (  email   text,   phoneNumber   int  ";

            var arguments = CreateUtils.GetArgumentsFromQuery(query);

            var actual = CreateUtils.GetColumnsFromArguments(arguments);

            var expected = new string[][] {
                new string[] { "email", "text" },
                new string[] { "phoneNumber", "int"}
            };

            Assert.Equal(expected, actual);
        }
    }
}