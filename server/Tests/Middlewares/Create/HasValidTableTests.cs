using PathonDB.Middlewares.Create;
using Xunit;
using PathonDB.Models.Database;
using Autofac.Extras.Moq;
using PathonDB.Exceptions.Create;

namespace PathonDB.Tests.Middlewares.Create {
    public class HasValidTableTests {
        [Theory]
        [InlineData("CREATE TABLE   animals   (email text,phoneNumber int, isAdult boolean);")]
        [InlineData("CREATE TABLE ITEMSS  (email text,phoneNumber int, isAdult boolean);")]
        public void Check_ValidTable_ShouldReturnTrue(string query) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTableNames()).Returns(new string[2] { "users", "items" });

                var middleware = mock.Create<HasValidTable>();

                var actual = middleware.Check(query);

                Assert.True(actual);
            }
        }

        [Theory]
        [InlineData("CREATE TABLE  users   (email text,phoneNumber int, isAdult boolean);")]
        [InlineData("CREATE TABLE   Items   (email text,phoneNumber int, isAdult boolean);")]
        [InlineData("CREATE TABLE   USERs   (email text,phoneNumber int, isAdult boolean);")]
        public void Check_TableWhichAlreadyExists_ShouldThrowTableAlreadyExistsException(string query) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTableNames()).Returns(new string[2] { "users", "items" });

                var middleware = mock.Create<HasValidTable>();

                Assert.Throws<TableAlreadyExistsException>(() => middleware.Check(query));
            }
        }

        [Theory]
        [InlineData("CREATE TABLE __ (email text,phoneNumber int, isAdult boolean);")]
        [InlineData("CREATE TABLE dak31451 (email text,phoneNumber int, isAdult boolean);")]
        [InlineData("CREATE TABLE ???Daida (email text,phoneNumber int, isAdult boolean);")]
        public void Check_TableWithForbiddenName_ShouldThrowForbiddenTableNameException(string query) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>();

                var middleware = mock.Create<HasValidTable>();

                Assert.Throws<ForbiddenTableNameException>(() => middleware.Check(query));
            }
        }
    }
}