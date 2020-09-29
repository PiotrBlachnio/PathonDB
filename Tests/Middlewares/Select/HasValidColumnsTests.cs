using Autofac.Extras.Moq;
using PathonDB.Exceptions.General;
using PathonDB.Middlewares.Select;
using PathonDB.Models.Database;
using Xunit;

namespace PathonDB.Tests.Middlewares.Select {
    public class HasValidColumnsTests {
        [Theory]
        [InlineData("SELECT * FROM users")]
        [InlineData("   SELECT   (email)   FROM    users    ")]
        [InlineData("SELECT (Id, email) FROM users")]
        [InlineData("   SELECT   (isAdult, id)   FroM    users  ;  ")]
        [InlineData("SELECT (isAdult,   id  ,   phoneNumber) FROM users WHERE isAdult=true")]
        [InlineData("   SELECT   (   isAdult  ,    id   ,   phoneNumber   )   FROM    users  wheRe    isAdult    = true    ")]
        public void Check_ValidColumns_ShouldReturnTrue(string query) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTable("users")).Returns(new MockedTable());

                var middleware = mock.Create<HasValidColumns>();

                var actual = middleware.Check(query);

                Assert.True(actual);
            }
        }

        [Theory]
        [InlineData("   SELECT   (emaill)   FROM    users    ")]
        [InlineData("SELECT (Id, email, username) FROM users")]
        [InlineData("   SELECT   (isAdult, _id)   FroM    users  ;  ")]
        [InlineData("SELECT (isAdult,   id  ,   phoneNumber, IDD) FROM users WHERE isAdult=true")]
        [InlineData("   SELECT   (   isAdult  ,    id   ,   phoneNumberr   )   FROM    users  wheRe    isAdult    = true    ")]
        public void Check_InvalidColumns_ShouldThrowUnknownColumnNameException(string query) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTable("users")).Returns(new MockedTable());

                var middleware = mock.Create<HasValidColumns>();

                Assert.Throws<UnknownColumnNameException>(() => middleware.Check(query));
            }
        }
    }
}