using JsonDatabase.Exceptions.General;
using JsonDatabase.Middlewares.Create;
using Xunit;

namespace JsonDatabase.Tests.Middlewares.Create {
    public class HasValidArgumentsTests {
        [Theory]
        [InlineData("CREATE TABLE users (email text, phoneNumber int);")]
        public void Check_ValidQuery_ShouldReturnTrue(string query) {
            var middleware = new HasValidArguments();

            var actual = middleware.Check(query);

            Assert.True(actual);
        }

        [Theory]
        [InlineData("CREATE TABLE users (email (text, phoneNumber int);")]
        [InlineData("CREATE TABLE users email text, phoneNumber int);")]
        [InlineData("CREATE TABLE users ((email (text, phoneNumber int);")]
        public void Check_InvalidQuery_ShouldThrowMalformedArgumentsException(string query) {
            var middleware = new HasValidArguments();

            var ex = Assert.Throws<MalformedArgumentsException>(() => middleware.Check(query));

            Assert.Equal("Query has malformed arguments", ex.Message);
        }
    }
}