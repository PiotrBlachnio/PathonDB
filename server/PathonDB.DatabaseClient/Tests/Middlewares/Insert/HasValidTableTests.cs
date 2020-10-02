using Autofac.Extras.Moq;
using PathonDB.DatabaseClient.Exceptions.General;
using PathonDB.DatabaseClient.Middlewares.Insert;
using PathonDB.DatabaseClient.Models.Database;
using Xunit;

namespace PathonDB.DatabaseClient.Tests.Middlewares.Insert {
    public class HasValidTableTests {
        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO  ItemS (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO   USERS  (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        public void Check_ValidTable_ShouldReturnTrue(string query) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTableNames()).Returns(new string[2] {"users", "items"});

                var middleware = mock.Create<HasValidTable>();

                var actual = middleware.Check(query);

                Assert.True(actual);
            }
        }

        [Theory]
        [InlineData("INSERT INTO user (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO itemms  (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        public void Check_InvalidTable_ShouldThrowTableNotFoundException(string query) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTableNames()).Returns(new string[2] {"users", "items"});

                var middleware = mock.Create<HasValidTable>();

                Assert.Throws<TableNotFoundException>(() => middleware.Check(query));
            }
        }
    }
}