using System.Collections.Generic;
using JsonDatabase.Models;
using JsonDatabase.Services;
using Xunit;

namespace JsonDatabase.Tests.Services {
    public class CreateServiceTests {
        [Theory]
        [InlineData("CREATE TABLE users (email text, phoneNumber int, isAdult boolean);")]
         [InlineData("CREATE TABLE   users   (email   text,   phoneNumber  int ,  isAdult  boolean );")]
        public void CreateTable_ShouldCreateNewTableInDatabase(string query) {
            var database = new Database();

            new CreateService(database).PerformQuery(query);

            var actual = database.GetTable("users").GetColumnTypes();

            var expected = new Dictionary<string, string> {
                {"email", "text"},
                {"phoneNumber", "int"},
                {"isAdult", "boolean"}
            };

            Assert.Equal(actual, expected);
        }
    }
}