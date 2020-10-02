using Autofac.Extras.Moq;
using PathonDB.DatabaseClient.Exceptions.General;
using PathonDB.DatabaseClient.Middlewares.Select;
using PathonDB.DatabaseClient.Models.Database;
using Xunit;

namespace PathonDB.DatabaseClient.Tests.Middlewares.Select {
    public class HasValidConditionValueTypeTests {
        [Theory]
        [InlineData("SELECT * FROM users")]
        [InlineData("   SELECT   (email)   FROM    users    ")]
        [InlineData("SELECT (Id, email) FROM users")]
        [InlineData("   SELECT   (isAdult, id)   FroM    users  ;  ")]
        [InlineData("SELECT (isAdult,   id  ,   phoneNumber) FROM users WHERE isAdult=true")]
        [InlineData("   SELECT   (   isAdult  ,    id   ,   phoneNumber   )   FROM    users  wheRe    isAdult    = true    ")]
        public void Check_ValidConditionValueType_ShouldReturnTrue(string query) {
            using(var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTable("users")).Returns(new MockedTable());

                var middleware = mock.Create<HasValidConditionValueType>();

                var actual = middleware.Check(query);

                Assert.True(actual);
            }
        }

        [Theory]
        [InlineData("SELECT (isAdult,   id  ,   phoneNumber) FROM users WHERE isAdult=\"true\"")]
        [InlineData("   SELECT   (   isAdult  ,    id   ,   phoneNumber   )   FROM    users  wheRe    isAdult    = 5151    ")]
        public void Check_InvalidConditionValueType_ShouldThrowInvalidColumnTypeException(string query) {
            using(var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTable("users")).Returns(new MockedTable());

                var middleware = mock.Create<HasValidConditionValueType>();

                Assert.Throws<InvalidColumnTypeException>(() => middleware.Check(query));
            }
        }
    }
}