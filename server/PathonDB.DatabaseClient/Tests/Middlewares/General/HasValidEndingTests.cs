using PathonDB.DatabaseClient.Exceptions.General;
using PathonDB.DatabaseClient.Middlewares.General;
using Xunit;

namespace PathonDB.DatabaseClient.Tests.Middlewares.General {
    public class HasValidEndingTests {
        [Theory]
        [InlineData("CREATE TABLE users (email text, phoneNumber int);", ");")]
        [InlineData("CREATE TABLE users (email text, phoneNumber int );", ");")]
        [InlineData("CREATE TABLE users (email text, phoneNumber int)  ;", ")  ;")]
        [InlineData("CREATE TABLE users (email text, phoneNumber int)  ..;", "  ..;")]
        public void Check_ValidEnding_ShouldReturnTrue(string query, string validEnding) {
            var middleware = new HasValidEnding(validEnding);

            var actual = middleware.Check(query);

            Assert.True(actual);
        }

        [Theory]
        [InlineData("CREATE TABLE users (email text, phoneNumber int);", " );")]
        [InlineData("CREATE TABLE users (email text, phoneNumber int);", "); ")]
        [InlineData("CREATE TABLE users (email text, phoneNumber int) ;", ");")]
        public void Check_InvalidEnding_ShouldThrowInvalidQueryEndingException(string query, string validEnding) {
            var middleware = new HasValidEnding(validEnding);

            Assert.Throws<InvalidQueryEndingException>(() => middleware.Check(query));
        }
    }
}