using JsonDatabase.Exceptions.General;
using JsonDatabase.Middlewares.Create;
using Xunit;

namespace JsonDatabase.Tests.Middlewares.Create {
    public class HasValidArgumentsTests {
        [Fact] 
        public void Check_ValidQuery_ShouldReturnTrue() {
            var query = "Correct: CREATE TABLE users (email text, phoneNumber int);";
            var middleware = new HasValidArguments();

            var actual = middleware.Check(query);

            Assert.True(actual);
        }

        [Theory]
        [InlineData("Correct: CREATE TABLE users (email (text, phoneNumber int);")]
        [InlineData("Correct: CREATE TABLE users email text, phoneNumber int);")]
        [InlineData("Correct: CREATE TABLE users ((email (text, phoneNumber int);")]
        public void Check_InvalidQuery_ShouldThrowMalformedArgumentsException(string query) {
            var middleware = new HasValidArguments();

            var ex = Assert.Throws<MalformedArgumentsException>(() => middleware.Check(query));

            Assert.Equal("Query has malformed arguments", ex.Message);
        }
    }
}