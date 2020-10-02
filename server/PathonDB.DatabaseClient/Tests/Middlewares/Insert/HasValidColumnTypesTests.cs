using Autofac.Extras.Moq;
using PathonDB.DatabaseClient.Exceptions.General;
using PathonDB.DatabaseClient.Middlewares.Insert;
using PathonDB.DatabaseClient.Models.Database;
using Xunit;

namespace PathonDB.DatabaseClient.Tests.Middlewares.Insert {
    public class HasValidColumnTypesTests {
        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503")]
        [InlineData("INSERT INTO users (isAdult) VALUES (  true  ")]
        public void Check_ValidColumnTypes_ShouldReturnTrue(string query) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTable("users")).Returns(new MockedTable());

                var middleware = mock.Create<HasValidColumnTypes>();

                var actual = middleware.Check(query);

                Assert.True(actual);
            }
        }

        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", \"703503\"")]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (Jeff@gmail.com, 703503")]
        [InlineData("INSERT INTO users (isAdult) VALUES (truef")]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", true")]
        public void Check_InvalidColumnTypes_ShouldThrowInvalidColumnTypeException(string query) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTable("users")).Returns(new MockedTable());

                var middleware = mock.Create<HasValidColumnTypes>();

                Assert.Throws<InvalidColumnTypeException>(() => middleware.Check(query));
            }
        }
    }
}