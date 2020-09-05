using System.Collections.Generic;
using Autofac.Extras.Moq;
using JsonDatabase.Exceptions.Insert;
using JsonDatabase.Middlewares.Insert;
using JsonDatabase.Models;
using Moq;
using Xunit;

namespace JsonDatabase.Tests.Middlewares.Insert {
    public class HasValidColumnNumberTests {
        public class MockedTable : ITable
        {
            public void AddColumn(Column column)
            {
                throw new System.NotImplementedException();
            }

            public void AddRow(string[] columns, string[] values)
            {
                throw new System.NotImplementedException();
            }

            public string[] GetColumnNames()
            {
                return new string[2] { "email", "phoneNumber" };
            }

            public Dictionary<string, string> GetColumnTypes()
            {
                throw new System.NotImplementedException();
            }
        }

        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);", "users")]
        [InlineData("INSERT INTO users (  email ,   phoneNumber  ) VALUES (\"Jeff@gmail.com\", 703503);", "users")]
        [InlineData("INSERT INTO users (email,   ) VALUES (\"Jeff@gmail.com\", 703503);", "users")]
        public void Check_ValidColumnNumber_ShouldReturnTrue(string query, string tableName) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTable(tableName)).Returns(new MockedTable());

                var middleware = mock.Create<HasValidColumnNumber>();

                var actual = middleware.Check(query);

                Assert.True(actual);
            }
        }
        
        [Theory]
        [InlineData("INSERT INTO users (email) VALUES (\"Jeff@gmail.com\", 703503);", "users", 1)]
        [InlineData("INSERT INTO users (   ) VALUES (\"Jeff@gmail.com\", 703503);", "users", 0)]
        [InlineData("INSERT INTO users (email, username, password) VALUES (\"Jeff@gmail.com\", 703503);", "users", 3)]
        [InlineData("INSERT INTO users (email, username,  ) VALUES (\"Jeff@gmail.com\", 703503);", "users", 3)]
        public void Check_InvalidColumnNumber_ShouldThrowInvalidColumnNumberException(string query, string tableName, int actualColumnNumber) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTable(tableName)).Returns(new MockedTable());

                var middleware = mock.Create<HasValidColumnNumber>();

                var ex = Assert.Throws<InvalidColumnNumberException>(() => middleware.Check(query));

                Assert.Equal($"Expected column number: 2, received: {actualColumnNumber}", ex.Message);
            }
        }
    }
}