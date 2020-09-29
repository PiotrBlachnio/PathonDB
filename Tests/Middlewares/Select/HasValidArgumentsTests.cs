using PathonDB.Middlewares.Select;
using Xunit;

namespace PathonDB.Tests.Middlewares.Select {
    public class HasValidArgumentsTests {
        [Theory]
        [InlineData("SELECT * FROM users;")]
        [InlineData("   SELECT   *   FROM    users  ;  ")]
        [InlineData("SELECT (username, email) FROM users;")]
        [InlineData("   SELECT   (username, email)   FroM    users  ;  ")]
        [InlineData("SELECT * FROM users WHERE isAdult=true;")]
        [InlineData("   SELECT   *   FROM    users  wheRe    isAdult    = true  ;  ")]
        public void Check_ValidArguments_ShouldReturnTrue(string query) {
            var middleware = new HasValidArguments();

            var actual = middleware.Check(query);

            Assert.True(actual);
        }
    }
}