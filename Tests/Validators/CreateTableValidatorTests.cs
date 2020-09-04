using JsonDatabase.Exceptions.Create;
using JsonDatabase.Exceptions.General;
using JsonDatabase.Models;
using JsonDatabase.Validators.Create;
using Xunit;

namespace JsonDatabase.Tests.Validators {
    public class CreateTableValidatorTests {
        [Theory]
        [InlineData("CREATE TABLE users (email text, phoneNumber int);")]
        [InlineData("CREATE TABLE   users   (email text, phoneNumber int);")]
        [InlineData("CREATE TABLE users (   email   text  , phoneNumber   int);")]
        [InlineData("   CREATE   TABLE   users (email  text, phoneNumber int    );")]
        public void Validate_ValidQuery_ShouldReturnTrue(string query) {
            var validator = new CreateTableValidator(new Database());

            var actual = validator.Validate(query);

            Assert.True(actual);
        }

        [Fact]
        public void Validate_QueryContainsIncorrectArguments_ShouldThrowMalformedArgumentsException() {
            var validator = new CreateTableValidator(new Database());

            var query = "GET * FROM users;";

            var ex = Assert.Throws<MalformedArgumentsException>(() => validator.Validate(query));
        }

        [Fact]
        public void Validate_QueryContainsIncorrectTableName_ShouldThrowTableAlreadyExistsException() {
            var validator = new CreateTableValidator(new Database());

            var query = "CREATE TABLE (email text, phoneNumber int);";

            var ex = Assert.Throws<TableAlreadyExistsException>(() => validator.Validate(query));
        }
    }
}