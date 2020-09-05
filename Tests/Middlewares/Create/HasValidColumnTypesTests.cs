using JsonDatabase.Exceptions.Create;
using JsonDatabase.Middlewares.Create;
using Xunit;

namespace JsonDatabase.Tests.Middlewares.Create {
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
        [InlineData("CREATE TABLE users (email textt, phoneNumber int", "textt")]
        [InlineData("CREATE TABLE users (email Integer", "Integer")]
        [InlineData("CREATE TABLE users (email text, isAdult bool", "bool")]
        public void Check_InvalidColumnTypes_ShouldThrowUnsupportedTypeException(string query, string type) {
            var middleware = new HasValidColumnTypes();

            var ex = Assert.Throws<UnsupportedTypeException>(() => middleware.Check(query));

            Assert.Equal($"Unsupported type found in query: {type}", ex.Message);
        }
    }
}