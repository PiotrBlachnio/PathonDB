using Autofac.Extras.Moq;
using PathonDB.Exceptions.Insert;
using PathonDB.Middlewares.Insert;
using PathonDB.Models;
using Xunit;

namespace PathonDB.Tests.Middlewares.Insert {
    public class HasValidColumnNumberTests {
        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber, isAdult) VALUES (\"Jeff@gmail.com\", 703503, true);")]
        [InlineData("INSERT INTO users (  email ,   phoneNumber,  isAdult  ) VALUES (\"Jeff@gmail.com\", 703503, true);")]
        [InlineData("INSERT INTO users (email,     phoneNumber,       isAdult ) VALUES (\"Jeff@gmail.com\", 703503, true);")]
        public void Check_ValidColumnNumber_ShouldReturnTrue(string query) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTable("users")).Returns(new MockedTable());

                var middleware = mock.Create<HasValidColumnNumber>();

                var actual = middleware.Check(query);

                Assert.True(actual);
            }
        }
        
        [Theory]
        [InlineData("INSERT INTO users (email) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (   ) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (email, username, password, isAdult) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (email, username,  ,  ) VALUES (\"Jeff@gmail.com\", 703503);")]
        public void Check_InvalidColumnNumber_ShouldThrowInvalidColumnNumberException(string query) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTable("users")).Returns(new MockedTable());

                var middleware = mock.Create<HasValidColumnNumber>();

                Assert.Throws<InvalidColumnNumberException>(() => middleware.Check(query));
            }
        }
    }
}