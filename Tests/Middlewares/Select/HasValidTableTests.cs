using Autofac.Extras.Moq;
using PathonDB.Middlewares.Select;
using PathonDB.Models.Database;
using Xunit;

namespace PathonDB.Tests.Middlewares.Select {
    public class HasValidTableTests {
        [Theory]
        [InlineData("SELECT * FROM users")]
        [InlineData("   SELECT   (email)   FROM    users    ")]
        [InlineData("SELECT (Id, email) FROM users")]
        [InlineData("   SELECT   (isAdult, id)   FroM    users  ;  ")]
        [InlineData("SELECT (isAdult,   id  ,   phoneNumber) FROM users WHERE isAdult=true")]
        [InlineData("   SELECT   (   isAdult  ,    id   ,   phoneNumber   )   FROM    users  wheRe    isAdult    = true    ")]
        public void Check_ValidTableName_ShouldReturnTrue(string query) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTableNames()).Returns(new string[] { "users", "items" });

                var middleware = mock.Create<HasValidTable>();

                var actual = middleware.Check(query);

                Assert.True(actual);
            }
        }
    }
}