using System.Collections.Generic;
using PathonDB.Models.Database;
using Xunit;

namespace PathonDB.Services {
    public class InsertServiceTests {
        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber, isAdult) VALUES (\"Jeff@gmail.com\", 703503, true);")]
        [InlineData("INSERT INTO   uSERs    (  email,   phoneNumber, isAdult)   VALueS   ( \"Jeff@gmail.com\",   703503,   true);")]
        public void InsertRow_ShouldAddRowInTheTable(string query) {
            var database = new Database();

            new CreateService(database).PerformQuery("CREATE TABLE users (email text, phoneNumber int, isAdult boolean);");
            new InsertService(database).PerformQuery(query);

            var id = database.GetTable("users").IdList[0];
            var actual = database.GetTable("users").GetRecordById(id);

            var expected = new PathonDB.Models.Table.Record(new List<string>() {
                "email",
                "phoneNumber",
                "isAdult"
            }, new List<object>() {
                "Jeff@gmail.com",
                703503,
                true
            });

            Assert.Equal(expected.ColumnNames, actual.ColumnNames);
            Assert.Equal(expected.Values, actual.Values);
        }
    }
}