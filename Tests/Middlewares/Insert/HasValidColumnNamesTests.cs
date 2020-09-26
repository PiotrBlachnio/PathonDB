using Autofac.Extras.Moq;
using PathonDB.Exceptions.General;
using PathonDB.Middlewares.Insert;
using PathonDB.Models.Database;
using Xunit;

namespace PathonDB.Tests.Middlewares.Insert {
    public class HasValidColumnNamesTests {
        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (email,   phoneNumber  ) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (  email  ,   phoneNumber  ) VALUES (\"Jeff@gmail.com\", 703503);")]
        public void Check_ValidColumnNames_ShouldReturnTrue(string query) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTable("users")).Returns(new MockedTable());

                var middleware = mock.Create<HasValidColumnNames>();

                var actual = middleware.Check(query);

                Assert.True(actual);
            }
        }

        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber, username) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (email, phoneNumbe) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (EMAIL, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        public void Check_InvalidColumnNames_ShouldThrowUnknownColumnNameException(string query) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTable("users")).Returns(new MockedTable());

                var middleware = mock.Create<HasValidColumnNames>();

                Assert.Throws<UnknownColumnNameException>(() => middleware.Check(query));
            }
        }
    }
}