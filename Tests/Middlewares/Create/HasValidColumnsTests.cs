using JsonDatabase.Exceptions.General;
using JsonDatabase.Middlewares.Create;
using Xunit;

namespace JsonDatabase.Tests.Middlewares.Create {
    public class HasValidColumnsTests {
        [Theory]
        [InlineData("CREATE TABLE users (email text, phoneNumber int")]
        [InlineData("CREATE TABLE users (  email    text   ,phoneNumber int  ")]
        public void Check_ValidQuery_ShouldReturnTrue(string query) {
            var middleware = new HasValidColumns();

            var actual = middleware.Check(query);

            Assert.True(actual);
        }

        [Theory]
        [InlineData("CREATE TABLE users (email   , phoneNumber int")]
        [InlineData("CREATE TABLE users (email int, ")]
        public void Check_InvalidQuery_ShouldThrowMalformedColumnsException(string query) {
            var middleware = new HasValidColumns();

            var ex = Assert.Throws<MalformedColumnsException>(() => middleware.Check(query));

            Assert.Equal("Query has malformed columns", ex.Message);
        }

        [Theory]
        [InlineData("CREATE TABLE users (id text, phoneNumber int", "id")]
        [InlineData("CREATE TABLE users (Id text, phoneNumber int", "Id")]
        [InlineData("CREATE TABLE users (ID text, phoneNumber int", "ID")]
        public void Check_ForbiddenColumnName_ShouldThrowForbiddenColumnNameException(string query, string columnName) {
            var middleware = new HasValidColumns();

            var ex = Assert.Throws<ForbiddenColumnNameException>(() => middleware.Check(query));

            Assert.Equal($"Column name \"{columnName}\" is not allowed", ex.Message);
        }
    }
}