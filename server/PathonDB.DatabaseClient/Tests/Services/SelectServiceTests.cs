using System.Collections.Generic;
using PathonDB.Models.Database;
using PathonDB.Services;
using Xunit;

namespace PathonDB.Tests.Services {
    public class SelectServiceTests {
        [Theory]
        [InlineData("SELECT * FROM users;")]
        [InlineData("   SELECT    *    FROM    users   ;    ")]
        public void PerformQuery_AsteriksSymbolWithNoCondition_ShouldReturnValidRecords(string query) {
            var database = new Database();

            new CreateService(database).PerformQuery("CREATE TABLE users (email text, phoneNumber int, isAdult boolean);");
            new InsertService(database).PerformQuery("INSERT INTO users (email, phoneNumber, isAdult) VALUES (\"Jeff@gmail.com\", 703503, true);");
            new InsertService(database).PerformQuery("INSERT    INTO   users    (isAdult,  email,  phoneNumber )  VALUES  (false, \"Arnold@gmail.com\", 141505);");

            var actual = new SelectService(database).PerformQuery(query);

            var firstRecord = new Models.Table.Record(new List<string>() { "email", "phoneNumber", "isAdult" }, new List<object>() { "Jeff@gmail.com", 703503, true });
            var secondRecord = new Models.Table.Record(new List<string>() { "email", "phoneNumber", "isAdult" }, new List<object>() { "Arnold@gmail.com", 141505, false });
            
            var expected = new Models.Table.Record[] {
                firstRecord,
                secondRecord
            };

            for(var i = 0; i < actual.Length; i++) {
                Assert.Equal(actual[0].ColumnNames, expected[0].ColumnNames);
                Assert.Equal(actual[0].Values, expected[0].Values);
            }
        }

        [Theory]
        [InlineData("SELECT * FROM users WHERE isAdult=true;")]
        [InlineData("   SELECT    *    FROM    users   wheRe isAdult = true  ;    ")]
        public void PerformQuery_AsteriksSymbolWithCondition_ShouldReturnValidRecords(string query) {
            var database = new Database();

            new CreateService(database).PerformQuery("CREATE TABLE users (email text, phoneNumber int, isAdult boolean);");
            new InsertService(database).PerformQuery("INSERT INTO users (email, phoneNumber, isAdult) VALUES (\"Jeff@gmail.com\", 703503, true);");
            new InsertService(database).PerformQuery("INSERT    INTO   users    (isAdult,  email,  phoneNumber )  VALUES  (false, \"Arnold@gmail.com\", 141505);");

            var actual = new SelectService(database).PerformQuery(query);

            var expected = new Models.Table.Record[] {
                new Models.Table.Record(new List<string>() { "email", "phoneNumber", "isAdult" }, new List<object>() { "Jeff@gmail.com", 703503, true })
            };

            for(var i = 0; i < actual.Length; i++) {
                Assert.Equal(actual[0].ColumnNames, expected[0].ColumnNames);
                Assert.Equal(actual[0].Values, expected[0].Values);
            }
        }

        [Theory]
        [InlineData("SELECT (phoneNumber, isAdult) FROM users;")]
        [InlineData("   SELECT    (    phoneNumber   ,    isAdult   )   FROM    users  ;    ")]
        public void PerformQuery_MultipleColumnsWithNoCondition_ShouldReturnValidRecords(string query) {
            var database = new Database();

            new CreateService(database).PerformQuery("CREATE TABLE users (email text, phoneNumber int, isAdult boolean);");
            new InsertService(database).PerformQuery("INSERT INTO users (email, phoneNumber, isAdult) VALUES (\"Jeff@gmail.com\", 703503, true);");
            new InsertService(database).PerformQuery("INSERT    INTO   users    (isAdult,  email,  phoneNumber )  VALUES  (false, \"Arnold@gmail.com\", 141505);");

            var actual = new SelectService(database).PerformQuery(query);

            var firstRecord = new Models.Table.Record(new List<string>() { "phoneNumber", "isAdult" }, new List<object>() { 703503, true });
            var secondRecord = new Models.Table.Record(new List<string>() { "phoneNumber", "isAdult" }, new List<object>() { 141505, false });
            
            var expected = new Models.Table.Record[] {
                firstRecord,
                secondRecord
            };

            for(var i = 0; i < actual.Length; i++) {
                Assert.Equal(actual[0].ColumnNames, expected[0].ColumnNames);
                Assert.Equal(actual[0].Values, expected[0].Values);
            }
        }

        [Theory]
        [InlineData("SELECT (phoneNumber, isAdult) FROM users WHERE isAdult=false;")]
        [InlineData("   SELECT    (    phoneNumber   ,    isAdult   )   FROM    users  wHerE   isAdult   =   false;    ")]
        public void PerformQuery_MultipleColumnsWithCondition_ShouldReturnValidRecords(string query) {
            var database = new Database();

            new CreateService(database).PerformQuery("CREATE TABLE users (email text, phoneNumber int, isAdult boolean);");
            new InsertService(database).PerformQuery("INSERT INTO users (email, phoneNumber, isAdult) VALUES (\"Jeff@gmail.com\", 703503, true);");
            new InsertService(database).PerformQuery("INSERT    INTO   users    (isAdult,  email,  phoneNumber )  VALUES  (false, \"Arnold@gmail.com\", 141505);");

            var actual = new SelectService(database).PerformQuery(query);
            
            var expected = new Models.Table.Record[] {
                new Models.Table.Record(new List<string>() { "phoneNumber", "isAdult" }, new List<object>() { 141505, false })
            };

            for(var i = 0; i < actual.Length; i++) {
                Assert.Equal(actual[0].ColumnNames, expected[0].ColumnNames);
                Assert.Equal(actual[0].Values, expected[0].Values);
            }
        }
    }
}