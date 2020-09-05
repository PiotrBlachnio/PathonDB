using JsonDatabase.Middlewares.Create;
using Xunit;
using JsonDatabase.Models;
using Autofac.Extras.Moq;
using JsonDatabase.Exceptions.Create;

namespace JsonDatabase.Tests.Middlewares.Create {
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
        [InlineData("CREATE TABLE  users   (email text,phoneNumber int, isAdult boolean);", "users")]
        [InlineData("CREATE TABLE   Items   (email text,phoneNumber int, isAdult boolean);", "items")]
        [InlineData("CREATE TABLE   USERs   (email text,phoneNumber int, isAdult boolean);", "users")]
        public void Check_TableWhichAlreadyExists_ShouldThrowTableAlreadyExistsException(string query, string table) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTableNames()).Returns(new string[2] { "users", "items" });

                var middleware = mock.Create<HasValidTable>();

                var ex = Assert.Throws<TableAlreadyExistsException>(() => middleware.Check(query));

                Assert.Equal($"Table already exist: \"{table}\"", ex.Message);
            }
        }

        [Theory]
        [InlineData("CREATE TABLE __ (email text,phoneNumber int, isAdult boolean);", "__")]
        [InlineData("CREATE TABLE dak31451 (email text,phoneNumber int, isAdult boolean);", "dak31451")]
        [InlineData("CREATE TABLE ???Daida (email text,phoneNumber int, isAdult boolean);", "???daida")]
        public void Check_TableWithForbiddenName_ShouldThrowForbiddenTableNameException(string query, string table) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>();

                var middleware = mock.Create<HasValidTable>();

                var ex = Assert.Throws<ForbiddenTableNameException>(() => middleware.Check(query));

                Assert.Equal($"Table name \"{table}\" is not allowed", ex.Message);
            }
        }
    }
}