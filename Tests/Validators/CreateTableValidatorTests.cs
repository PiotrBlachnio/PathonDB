using System;
using PathonDB.Models;
using PathonDB.Validators.Create;
using Xunit;

namespace PathonDB.Tests.Validators {
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
        [InlineData("CREATE TABLE (email text, phoneNumber int);")]
        [InlineData("CREATE TABLE 510da_ (email text, phoneNumber int);")]
        [InlineData("CREATE TABLE users (email text, phoneNumber int)")]
        [InlineData("CREATE TABLE users (email, phoneNumber int);")]
        [InlineData("CREATE TABLE users (email text, phoneNumber bigint);")]
        [InlineData("CREATE TABLE users (id text, email text);")]
        public void Validate_InvalidQuery_ShouldThrowAnException(string query) {
            var validator = new CreateTableValidator(new Database());

            Assert.ThrowsAny<Exception>(() => validator.Validate(query));
        }
    }
}