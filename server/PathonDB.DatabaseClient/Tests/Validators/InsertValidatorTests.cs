using System;
using PathonDB.DatabaseClient.Models.Database;
using PathonDB.DatabaseClient.Services;
using PathonDB.DatabaseClient.Validators;
using Xunit;

namespace PathonDB.DatabaseClient.Tests.Validators {
    public class InsertValidatorTests {
        private readonly IDatabase _database;

        public InsertValidatorTests() {
            _database = new Database();
            new CreateService(_database).PerformQuery("CREATE TABLE users (email text, phoneNumber int);");
        }

        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO   users   (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (  email  ,   phoneNumber  ) VALUeS (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (email ,  phoneNumber)    values   (   \"Jeff@gmail.com\"  ,   703503  );")]
        public void Validate_ValidQuery_ShouldReturnTrue(string query) {
            var validator = new InsertValidator(_database);

            var actual = validator.Validate(query);

            Assert.True(actual);
        }

        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUE (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (email phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503")]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\");")]
        [InlineData("INSERT INTO users (email) VALUES (\"Jeff@gmail.com\");")]
        [InlineData("INSERT INTO users (email, phoneNumberr) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", true);")]
        public void Validate_InvalidQuery_ShouldThrowAnException(string query) {
            var validator = new InsertValidator(_database);

            Assert.ThrowsAny<Exception>(() => validator.Validate(query));
        }
    }
}