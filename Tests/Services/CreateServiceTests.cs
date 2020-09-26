using PathonDB.Models;
using PathonDB.Models.Column;
using PathonDB.Services;
using Xunit;

namespace PathonDB.Tests.Services {
    public class CreateServiceTests {
        [Theory]
        [InlineData("CREATE TABLE users (email text, phoneNumber int, isAdult boolean);")]
        [InlineData("CREATE TABLE   users   (email   text,   phoneNumber  int ,  isAdult  boolean );")]
        public void CreateTable_ShouldCreateNewTableInDatabase(string query) {
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