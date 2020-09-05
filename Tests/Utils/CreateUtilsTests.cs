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
    }
}