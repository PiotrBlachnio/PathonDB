using System;
using PathonDB.DatabaseClient.Models.Database;
using PathonDB.DatabaseClient.Services;
using PathonDB.DatabaseClient.Validators;
using Xunit;

namespace PathonDB.DatabaseClient.Tests.Validators {
    public class SelectValidatorTests {
        private readonly IDatabase _database;

        public SelectValidatorTests() {
            _database = new Database();

            new CreateService(_database).PerformQuery("CREATE TABLE users (email text, phoneNumber int, isAdult boolean);");
            new InsertService(_database).PerformQuery("INSERT INTO users (email, phoneNumber, isAdult) VALUES (\"Jeff@gmail.com\", 703503, true);");
            new InsertService(_database).PerformQuery("INSERT    INTO   users    (isAdult,  email,  phoneNumber )  VALUES  (false, \"Arnold@gmail.com\", 141505);");
        }

        [Theory]
        [InlineData("SELECT * FROM users;")]
        [InlineData("   SELECT   (email)   FROM    users    ;")]
        [InlineData("SELECT (Id, email) FROM users;")]
        [InlineData("   SELECT   (isAdult, id)   FroM    users  ;  ")]
        [InlineData("SELECT (isAdult,   id  ,   phoneNumber) FROM users WHERE isAdult=true;")]
        [InlineData("   SELECT   (   isAdult  ,    id   ,   phoneNumber   )   FROM    users  wheRe    isAdult    = true   ; ")]
        public void Validate_ValidQuery_ShouldReturnTrue(string query) {
            var validator = new SelectValidator(_database);

            var actual = validator.Validate(query);

            Assert.True(actual);
        }

        [Theory]
        [InlineData("SELECT * FROM FROM users;")]
        [InlineData("   SELECT   (email)   ( FROM    users    ;")]
        [InlineData("SELECT (Id, email) FROM ) users;")]
        [InlineData("SELECT (Id, email FROM ) users;")]
        [InlineData("SELECT (Id_, email) FROM ) users;")]
        [InlineData("   SELECT   (isAdult, id)  = FroM    users  ;  ")]
        [InlineData("SELECT (isAdult,   id  ,   phoneNumber) FROM users WHERE isAdult==true;")]
        [InlineData("SELECT (isAdult,   id  ,   phoneNumber) FROM users WHERE isAdult=135151;")]
        [InlineData("   SELECT   (   isAdult  ,    id   ,   phoneNumber   )WHERE   wheRe    isAdult    = true FROM    users  wheRe    isAdult    = true   ; ")]
        public void Validate_InvalidQuery_ShouldThrowAnException(string query) {
            var validator = new SelectValidator(_database);

            Assert.ThrowsAny<Exception>(() => validator.Validate(query));
        }
    }
}