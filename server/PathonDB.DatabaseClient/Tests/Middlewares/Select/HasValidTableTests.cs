using Autofac.Extras.Moq;
using PathonDB.DatabaseClient.Exceptions.General;
using PathonDB.DatabaseClient.Middlewares.Select;
using PathonDB.DatabaseClient.Models.Database;
using Xunit;

namespace PathonDB.DatabaseClient.Tests.Middlewares.Select {
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

        [Theory]
        [InlineData("SELECT * FROM userss")]
        [InlineData("   SELECT   (email)   FROM        ")]
        [InlineData("SELECT (Id, email) FROM _")]
        [InlineData("   SELECT   (isAdult, id)   FroM    item  ;  ")]
        [InlineData("SELECT (isAdult,   id  ,   phoneNumber) FROM  WHERE isAdult=true")]
        [InlineData("   SELECT   (   isAdult  ,    id   ,   phoneNumber   )   FROM  wheRe    isAdult    = true    ")]
        public void Check_InvalidTableName_ShouldThrowTableNotFoundException(string query) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTableNames()).Returns(new string[] { "users", "items" });

                var middleware = mock.Create<HasValidTable>();

                Assert.Throws<TableNotFoundException>(() => middleware.Check(query));
            }
        }
    }
}