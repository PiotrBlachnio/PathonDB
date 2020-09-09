using System.Collections.Generic;
using JsonDatabase.Models;
using Xunit;

namespace JsonDatabase.Services {
    public class InsertServiceTests {
        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber, isAdult) VALUES (\"Jeff@gmail.com\", 703503, true);")]
        [InlineData("INSERT INTO   uSERs    (  email,   phoneNumber, isAdult)   VALueS   ( \"Jeff@gmail.com\",   703503,   true);")]
        public void InsertRow_ShouldAddRowInTheTable(string query) {
            var database = new Database();

            new CreateService(database).PerformQuery("CREATE TABLE users (email text, phoneNumber int, isAdult boolean);");
            new InsertService(database).PerformQuery(query);

            var id = database.GetTable("users").GetIdList()[0];
            var actual = database.GetTable("users").GetRowById(id);

            var expected = new Dictionary<string, object>() {
                {"email", "Jeff@gmail.com"},
                {"phoneNumber", 703503},
                {"isAdult", true}
            };

            Assert.Equal(expected, actual);
        }
    }
}