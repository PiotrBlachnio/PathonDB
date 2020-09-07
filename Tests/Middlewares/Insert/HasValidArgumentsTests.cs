using JsonDatabase.Exceptions.General;
using JsonDatabase.Middlewares.Insert;
using Xunit;

namespace JsonDatabase.Tests.Middlewares.Insert {
    public class HasValidArgumentsTests {
        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users   (email, phoneNumber)   VALUES    (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users   (email, phoneNumber)  values    (\"Jeff@gmail.com\", 703503);")]
        public void Check_ValidArguments_ShouldReturnTrue(string query) {
            var middleware = new HasValidArguments();

            var actual = middleware.Check(query);

            Assert.True(actual);
        }

        [Theory]
        [InlineData("INSERT INTO users email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users ((email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (   email, phoneNumber) VALUES   \"Jeff@gmail.com\", 703503);")]
        public void Check_InvalidArgumentsNumber_ShouldThrowMalformedArgumentsException(string query) {
            var middleware = new HasValidArguments();

            Assert.Throws<MalformedArgumentsException>(() => middleware.Check(query));
        }

        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber)  VALUE  (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUESs (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (email, phoneNumber)  ARGS (\"Jeff@gmail.com\", 703503);")]
        public void Check_InvalidKeyword_ShouldThrowMalformedArgumentsException(string query) {
            var middleware = new HasValidArguments();

            Assert.Throws<MalformedArgumentsException>(() => middleware.Check(query));
        }
    }
}