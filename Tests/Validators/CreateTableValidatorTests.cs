using System;
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

        [Theory]
        [InlineData("GET * FROM users;")]
        public void Validate_InvalidQuery_ShouldThrowAnException(string query) {
            var validator = new CreateTableValidator(new Database());

            Assert.ThrowsAny<Exception>(() => validator.Validate(query));
        }
    }
}