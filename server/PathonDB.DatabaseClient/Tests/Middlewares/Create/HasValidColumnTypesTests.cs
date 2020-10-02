using PathonDB.DatabaseClient.Exceptions.Create;
using PathonDB.DatabaseClient.Middlewares.Create;
using Xunit;

namespace PathonDB.DatabaseClient.Tests.Middlewares.Create {
    public class HasValidColumnTypesTests {
        [Theory]
        [InlineData("CREATE TABLE users (email text, phoneNumber int")]
        [InlineData("CREATE TABLE users (isAdult boolean, isWise BOOLean")]
        [InlineData("CREATE TABLE users (username   TEXT  ")]
        public void Check_ValidColumnTypes_ShouldReturnTrue(string query) {
            var middleware = new HasValidColumnTypes();

            var actual = middleware.Check(query);

            Assert.True(actual);
        }

        [Theory]
        [InlineData("CREATE TABLE users (email textt, phoneNumber int")]
        [InlineData("CREATE TABLE users (email Integer")]
        [InlineData("CREATE TABLE users (email text, isAdult bool")]
        public void Check_InvalidColumnTypes_ShouldThrowUnsupportedTypeException(string query) {
            var middleware = new HasValidColumnTypes();

            Assert.Throws<UnsupportedTypeException>(() => middleware.Check(query));
        }
    }
}