using System.Linq;
using JsonDatabase.Utils;
using Xunit;

namespace JsonDatabase.Tests.Utils {
    public class InsertUtilsTests {
        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users   (email, phoneNumber) VALUES   (\"Jeff@gmail.com\", 703503);")]
        public void GetArgumentsFromQuery_ShouldReturnValidStringArray(string query) {
            var actual = InsertUtils.GetArgumentsFromQuery(query);
            
            var expected = new string[3] { "INSERT INTO users", "email, phoneNumber) VALUES", "\"Jeff@gmail.com\", 703503);"};

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO USErs (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO   usErs    (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        public void GetTableNameFromQuery_ShouldReturnValidTableName(string query) {
            var actual = InsertUtils.GetTableNameFromQuery(query);

            var expected = "users";

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (email, phoneNumber)     VALUES    (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (email, phoneNumber) VAlues   (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (email, phoneNumber)      values (\"Jeff@gmail.com\", 703503);")]
        public void GetValuesKeywordFromArguments_ShouldReturnValidKeyword(string query) {
            var actual = InsertUtils.GetValuesKeywordFromArguments(InsertUtils.GetArgumentsFromQuery(query));

            var expected = "VALUES";

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber, isAdult) VALUES (\"Jeff@gmail.com\", 703503, true);")]
        [InlineData("INSERT INTO users (  email ,   phoneNumber  ,   isAdult   ) VALUES (\"Jeff@gmail.com\", 703503, true);")]
        [InlineData("INSERT INTO   users   (email,   phoneNumber,   isAdult  )   VALUES    (\"Jeff@gmail.com\", 703503, true);")]
        public void GetColumnsFromArguments_ShouldReturnValidColumns(string query) {
            var actual = InsertUtils.GetColumnsFromArguments(InsertUtils.GetArgumentsFromQuery(query)).ToArray();

            var expected = new string[] {
                "email",
                "phoneNumber",
                "isAdult"
            };

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber, isAdult) VALUES (\"Jeff@gmail.com\", 703503, true")]
        [InlineData("INSERT INTO users (email, phoneNumber, isAdult) VALUES (  \"Jeff@gmail.com\"  ,   703503  ,   true   ")]
        [InlineData("INSERT INTO users   (email, phoneNumber, isAdult   )    VALUES   (  \"Jeff@gmail.com\"  ,   703503  ,   true    ")]
        public void GetValuesFromArguments_ShouldReturnValidValues(string query) {
            var actual = InsertUtils.GetValuesFromArguments(InsertUtils.GetArgumentsFromQuery(query)).ToArray();

            var expected = new string[] {
                "\"Jeff@gmail.com\"",
                "703503",
                "true"
            };

            Assert.Equal(expected, actual);
        }
    }
}