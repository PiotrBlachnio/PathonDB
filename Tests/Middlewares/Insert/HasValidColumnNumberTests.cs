using System.Collections.Generic;
using Autofac.Extras.Moq;
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

        [Fact]
        public void Check_ValidColumnNumber_ShouldReturnTrue() {
            using (var mock = AutoMock.GetLoose()) {
                var query = "INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);";

                mock.Mock<IDatabase>().Setup(m => m.GetTable("users")).Returns(new MockedTable());

                var middleware = mock.Create<HasValidColumnNumber>();

                var actual = middleware.Check(query);

                Assert.True(actual);
            }
        }
    }
}