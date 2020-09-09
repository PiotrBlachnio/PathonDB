using JsonDatabase.Exceptions.General;
using JsonDatabase.Middlewares.General;
using Xunit;

namespace JsonDatabase.Tests.Middlewares.General {
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
        [InlineData("CREATE TABLE users (email text, phoneNumber int); ", ");")]
        [InlineData("CREATE TABLE users (email text, phoneNumber int) ;", ");")]
        public void Check_InvalidEnding_ShouldThrowInvalidQueryEndingException(string query, string validEnding) {
            var middleware = new HasValidEnding(validEnding);

            Assert.Throws<InvalidQueryEndingException>(() => middleware.Check(query));
        }
    }
}