using System.Collections.Generic;
using Autofac.Extras.Moq;
using JsonDatabase.Exceptions.General;
using JsonDatabase.Middlewares.Insert;
using JsonDatabase.Models;
using Xunit;

namespace JsonDatabase.Tests.Middlewares.Insert {
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
            return new string[2] { "email", "phoneNumber" };
        }

        public Dictionary<string, string> GetColumnTypes()
        {
            throw new System.NotImplementedException();
        }

        public IList<System.Guid> GetIdList()
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, object> GetRowById(System.Guid id)
        {
            throw new System.NotImplementedException();
        }
    }

    public class HasValidColumnNamesTests {
        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (email,   phoneNumber  ) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (  email  ,   phoneNumber  ) VALUES (\"Jeff@gmail.com\", 703503);")]
        public void Check_ValidColumnNames_ShouldReturnTrue(string query) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTable("users")).Returns(new MockedTable());

                var middleware = mock.Create<HasValidColumnNames>();

                var actual = middleware.Check(query);

                Assert.True(actual);
            }
        }

        [Theory]
        [InlineData("INSERT INTO users (email, phoneNumber, username) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (email, phoneNumbe) VALUES (\"Jeff@gmail.com\", 703503);")]
        [InlineData("INSERT INTO users (EMAIL, phoneNumber) VALUES (\"Jeff@gmail.com\", 703503);")]
        public void Check_InvalidColumnNames_ShouldThrowUnknownColumnNameException(string query) {
            using (var mock = AutoMock.GetLoose()) {
                mock.Mock<IDatabase>().Setup(m => m.GetTable("users")).Returns(new MockedTable());

                var middleware = mock.Create<HasValidColumnNames>();

                Assert.Throws<UnknownColumnNameException>(() => middleware.Check(query));
            }
        }
    }
}