using JsonDatabase.Utils;
using Xunit;

namespace JsonDatabase.Tests.Utils {
    public class CreateUtilsTests {
        [Theory]
        [InlineData("CREATE TABLE users (email text, phoneNumber int);", new string[2] { "CREATE TABLE users",  "email text, phoneNumber int);" })]
        [InlineData("CREATE TABLE users   (  email text, phoneNumber int);", new string[2] { "CREATE TABLE users",  "email text, phoneNumber int);" })]
        public void GetArgumentsFromQuery_ShouldReturnValidStringArray(string query, string[] expectedArguments) {
            var actual = CreateUtils.GetArgumentsFromQuery(query);

            Assert.Equal(actual, expectedArguments);
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
    }
}