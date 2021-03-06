using PathonDB.DatabaseClient.Models.Database;
using PathonDB.DatabaseClient.Models.Column;
using PathonDB.DatabaseClient.Services;
using Xunit;

namespace PathonDB.DatabaseClient.Tests.Services {
    public class CreateServiceTests {
        [Theory]
        [InlineData("CREATE TABLE users (email text, phoneNumber int, isAdult boolean);")]
        [InlineData("CREATE TABLE   users   (email   text,   phoneNumber  int ,  isAdult  boolean );")]
        public void PerformQuery_ShouldCreateNewTableInDatabase(string query) {
            var database = new Database();

            new CreateService(database).PerformQuery(query);

            var actual = database.GetTable("users").GetColumnProperties();

            var expected = new Properties[] {
                new Properties("email", "text"),
                new Properties("phoneNumber", "int"),
                new Properties("isAdult", "boolean")
            };

            for(var i = 0; i < expected.Length; i++) {
                Assert.Equal(expected[i].Name, actual[i].Name);
                Assert.Equal(expected[i].Type, actual[i].Type);
            }
        }
    }
}