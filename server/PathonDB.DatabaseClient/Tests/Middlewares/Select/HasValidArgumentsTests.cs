using PathonDB.DatabaseClient.Exceptions.General;
using PathonDB.DatabaseClient.Middlewares.Select;
using Xunit;

namespace PathonDB.DatabaseClient.Tests.Middlewares.Select {
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

        [Theory]
        [InlineData("SELECT  FROM users;")]
        [InlineData("   SELECT   -   FROM    users  ;  ")]
        [InlineData("SELECT // FROM users;")]
        [InlineData("   SELECT  )() (username, email)   FroM    users  ;  ")]
        [InlineData("SELECT )* FROM users WHERE isAdult=true;")]
        [InlineData("   SELECT   s*   FROM    users  wheRe    isAdult    = true  ;  ")]
        public void Check_InvalidColumnNames_ShouldThrowMalformedArgumentsException(string query) {
            var middleware = new HasValidArguments();

            Assert.Throws<MalformedArgumentsException>(() => middleware.Check(query));
        }

        [Theory]
        [InlineData("SELECT * fromm users;")]
        [InlineData("   SELECT   *   fFROM    users  ;  ")]
        [InlineData("SELECT (username, email) fromusers;")]
        [InlineData("   SELECT   (username, email)      users  ;  ")]
        [InlineData("SELECT *  where users WHERE isAdult=true;")]
        [InlineData("   SELECT   *from    users  wheRe    isAdult    = true  ;  ")]
        public void Check_InvalidFromKeyword_ShouldThrowMalformedArgumentsException(string query) {
            var middleware = new HasValidArguments();

            Assert.Throws<MalformedArgumentsException>(() => middleware.Check(query));
        }

        [Theory]
        [InlineData("SELECT * FROM users isAdult=true;")]
        [InlineData("   SELECT   *   FROM    users  isAdult=true;  ")]
        [InlineData("SELECT (username, email) FROM users wehre isAdult=true;")]
        [InlineData("   SELECT   (username, email)   FroM    usersWHERE isAdult = true  ;  ")]
        [InlineData("SELECT * FROM users WHEREe isAdult=true;")]
        [InlineData("   SELECT   *   FROM    users  wheReisAdult    = true  ;  ")]
        public void Check_InvalidWhereKeyword_ShouldThrowMalformedArgumentsException(string query) {
            var middleware = new HasValidArguments();

            Assert.Throws<MalformedArgumentsException>(() => middleware.Check(query));
        }
    }
}