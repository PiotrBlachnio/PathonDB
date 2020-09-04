using JsonDatabase.Middlewares.Create;
using Xunit;
using Moq;
using JsonDatabase.Models;
using Autofac.Extras.Moq;

namespace JsonDatabase.Tests.Middlewares.Create {
    public class HasValidTableTests {
        [Theory]
        [InlineData("CREATE TABLE   animals   (email text,phoneNumber int, isAdult boolean);")]
        public void Check_ValidTable_ShouldReturnTrue(string query) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<Database>().Setup(m => m.GetTableNames()).Returns(new string[2] { "users", "items" });

                var middleware = mock.Create<HasValidTable>();

                var actual = middleware.Check(query);

                Assert.True(actual);
            }
        }
    }
}