using PathonDB.Exceptions.General;
using PathonDB.Middlewares.General;
using Xunit;

namespace PathonDB.Tests.Middlewares.General {
    public class HasValidBeginningTests {
        [Theory]
        [InlineData("  CREATE   TABLE   users    (  email    text   , phoneNumber int, isAdult boolean);")]
        [InlineData("CREATE TABLE users  ( email    text   , phoneNumber int, isAdult boolean);")]
        [InlineData("create table users  ( email    text   , phoneNumber int, isAdult boolean);")]
        public void Check_ValidBeginning_ShouldReturnTrue(string query) {
            var middleware = new HasValidBeginning("CREATE TABLE");

            var actual = middleware.Check(query);

            Assert.True(actual);
        }

        [Theory]
        [InlineData("  CREeATE   TABLE   users    (  email    text   , phoneNumber int, isAdult boolean);")]
        [InlineData(" CREATE   tABLEe users  ( email    text   , phoneNumber int, isAdult boolean);")]
        [InlineData("crEte table users  ( email    text   , phoneNumber int, isAdult boolean);")]
        public void Check_InvalidBeginning_ShouldThrowInvalidQueryBeginningException(string query) {
            var middleware = new HasValidBeginning("CREATE TABLE");
            
            Assert.Throws<InvalidQueryBeginningException>(() => middleware.Check(query));
        }
    }
}