using PathonDB.DatabaseClient.Exceptions.General;
using PathonDB.DatabaseClient.Middlewares.Create;
using Xunit;

namespace PathonDB.DatabaseClient.Tests.Middlewares.Create {
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

            Assert.Throws<MalformedColumnsException>(() => middleware.Check(query));
        }

        [Theory]
        [InlineData("CREATE TABLE users (id text, phoneNumber int")]
        [InlineData("CREATE TABLE users (Id text, phoneNumber int")]
        [InlineData("CREATE TABLE users (ID text, phoneNumber int")]
        public void Check_IdAsAColumnName_ShouldThrowForbiddenColumnNameException(string query) {
            var middleware = new HasValidColumns();

            Assert.Throws<ForbiddenColumnNameException>(() => middleware.Check(query));
        }

        [Theory]
        [InlineData("CREATE TABLE users (email? text, phoneNumber int")]
        [InlineData("CREATE TABLE users (email text, phoneNumber! int")]
        [InlineData("CREATE TABLE users (email# text, phoneNumber int")]
        [InlineData("CREATE TABLE users (em$ail text, phoneNumber int")]
        [InlineData("CREATE TABLE users (email text, %phoneNumber int")]
        [InlineData("CREATE TABLE users (emai)l text, phoneNumber int")]
        [InlineData("CREATE TABLE users (emai^l text, phoneNumber int")]
        public void Check_ForbiddenCharacters_ShouldThrowForbiddenCharactersException(string query) {
            var middleware = new HasValidColumns();

            Assert.Throws<ForbiddenCharactersException>(() => middleware.Check(query));
        }
    }
}