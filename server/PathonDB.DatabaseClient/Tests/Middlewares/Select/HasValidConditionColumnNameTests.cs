using Autofac.Extras.Moq;
using PathonDB.DatabaseClient.Exceptions.General;
using PathonDB.DatabaseClient.Middlewares.Select;
using PathonDB.DatabaseClient.Models.Database;
using Xunit;

namespace PathonDB.DatabaseClient.Tests.Middlewares.Select {
    public class HasValidConditionColumnNameTests {
        [Theory]
        [InlineData("SELECT * FROM users")]
        [InlineData("   SELECT   (email)   FROM    users    ")]
        [InlineData("SELECT (Id, email) FROM users")]
        [InlineData("   SELECT   (isAdult, id)   FroM    users  ;  ")]
        [InlineData("SELECT (isAdult,   id  ,   phoneNumber) FROM users WHERE isAdult=true")]
        [InlineData("   SELECT   (   isAdult  ,    id   ,   phoneNumber   )   FROM    users  wheRe    isAdult    = true    ")]
        public void Check_ValidConditionColumnName_ShouldReturnTrue(string query) {
            using(var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTable("users")).Returns(new MockedTable());

                var middleware = mock.Create<HasValidConditionColumnName>();

                var actual = middleware.Check(query);

                Assert.True(actual);
            }
        }

        [Theory]
        [InlineData("SELECT (isAdult,   id  ,   phoneNumber) FROM users WHERE isAdultl=true")]
        [InlineData("   SELECT   (   isAdult  ,    id   ,   phoneNumber   )   FROM    users  wheRe   ll     = true    ")]
        public void Check_InvalidConditionColumnName_ShouldThrowUnknownColumnNameException(string query) {
            using(var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTable("users")).Returns(new MockedTable());

                var middleware = mock.Create<HasValidConditionColumnName>();

                Assert.Throws<UnknownColumnNameException>(() => middleware.Check(query));
            }
        }
    }
}