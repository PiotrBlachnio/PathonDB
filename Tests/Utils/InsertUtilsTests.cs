using JsonDatabase.Utils;
using Xunit;

namespace JsonDatabase.Tests.Utils {
    public class InsertUtilsTests {
        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO    users   (email, phoneNumber)   VALUES    (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        public void GetArgumentsFromQuery_ShouldReturnVaidStringArray(string query) {
            var actual = InsertUtils.GetArgumentsFromQuery(query);
            
            var expected = new string[3] { "INSERT INTO users", "email, phoneNumber) VALUES", "\"Jeff@gmail.com\", 703503);"};

            Assert.Equal(actual, expected);
        }
    }
}