using PathonDB.Exceptions.General;
using PathonDB.Middlewares.Insert;
using Xunit;

namespace PathonDB.Tests.Middlewares.Insert {
    public class HasValidColumnsTests {
        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (email,   phoneNumber  ) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (  email  ,   phoneNumber  ) VALUES (  \"Jeff@gmail.com\"  ,   703503  );")]
        public void Check_CorrespondingColumnsNumber_ShouldReturnTrue(string query) {
            var middleware = new HasValidColumns();

            var actual = middleware.Check(query);

            Assert.True(actual);
        }

        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503, 4151);")]
        [InlineData("INSERT INTO users (email) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (email, phoneNumber,   ) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (703503);")]
        public void Check_NotCorrespondingColumnsNumber_ShouldThrowMalformedColumnsException(string query) {
            var middleware = new HasValidColumns();

            Assert.Throws<MalformedColumnsException>(() => middleware.Check(query));
        }
    }
}