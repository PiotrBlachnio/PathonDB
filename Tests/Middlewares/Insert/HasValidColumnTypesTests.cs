using System.Collections.Generic;
using Autofac.Extras.Moq;
using JsonDatabase.Exceptions.Insert;
using JsonDatabase.Middlewares.Insert;
using JsonDatabase.Models;
using Xunit;

namespace JsonDatabase.Tests.Middlewares.Insert {
    public class HasValidColumnTypesTests {
        public class MockedTable : ITable {
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
                throw new System.NotImplementedException();
            }

            public Dictionary<string, string> GetColumnTypes()
            {
                return new Dictionary<string, string>() {
                    {"email", "text"},
                    {"phoneNumber", "int"},
                    {"isAdult", "boolean"}
                };
            }
        }

        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503")]
        [InlineData("INSERT INTO users (isAdult) VALUES (  true  ")]
        public void Check_ValidColumnTypes_ShouldReturnTrue(string query) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTable("users")).Returns(new MockedTable());

                var middleware = mock.Create<HasValidColumnTypes>();

                var actual = middleware.Check(query);

                Assert.True(actual);
            }
        }

        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", \"703503\"")]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (Jeff@gmail.com, 703503")]
        [InlineData("INSERT INTO users (isAdult) VALUES (truef")]
        public void Check_InvalidColumnTypes_ShouldThrowInvalidColumnTypeException(string query) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTable("users")).Returns(new MockedTable());

                var middleware = mock.Create<HasValidColumnTypes>();

                Assert.Throws<InvalidColumnTypeException>(() => middleware.Check(query));
            }
        }
    }
}