using PathonDB.Middlewares.Select;
using Xunit;

namespace PathonDB.Tests.Middlewares.Select {
    public class HasValidConditionTests {
        [Theory]
        [InlineData("SELECT * FROM users")]
        [InlineData("   SELECT   (email)   FROM    users    ")]
        [InlineData("SELECT (Id, email) FROM users")]
        [InlineData("   SELECT   (isAdult, id)   FroM    users  ;  ")]
        [InlineData("SELECT (isAdult,   id  ,   phoneNumber) FROM users WHERE isAdult=true")]
        [InlineData("   SELECT   (   isAdult  ,    id   ,   phoneNumber   )   FROM    users  wheRe    isAdult    = true    ")]
        public void Check_ValidCondition_ShouldReturnTrue(string query) {
            var middleware = new HasValidCondition();

            var actual = middleware.Check(query);

            Assert.True(actual);
        }
    }
}