using PathonDB.Utils;
using Xunit;

namespace PathonDB.Tests.Utils {
    public class GeneralUtilsTests {
        [Theory]
        [InlineData("4", 4)]
        [InlineData("\"Hello world\"", "Hello world")]
        [InlineData("false", false)]
        [InlineData("FALSE", false)]
        [InlineData("true", true)]
        [InlineData("TRUE", true)]
        public void TransformStringValueToRealValue_ShouldReturnCorrespondingValue(string value, object expectedValue) {
            var actual = GeneralUtils.TransformStringValueToRealValue(value);

            Assert.Equal(actual, expectedValue);
        }
        
        [Theory]
        [InlineData("text", "\"Hello\"")]
        [InlineData("int", "1666")]
        [InlineData("boolean", "true")]
        [InlineData("boolean", "false")]
        public void IsTypeValid_ValidType_ShouldReturnTrue(string type, string value) {
            var actual = GeneralUtils.IsTypeValid(type, value);

            Assert.True(actual);
        }

        [Theory]
        [InlineData("text", "Hello")]
        [InlineData("int", "\"161\"")]
        [InlineData("boolean", "\"true\"")]
        [InlineData("boolean", "\"false\"")]
        public void IsTypeValid_InvalidType_ShouldReturnFalse(string type, string value) {
            var actual = GeneralUtils.IsTypeValid(type, value);

            Assert.False(actual);
        }

        [Theory]
        [InlineData("hello")]
        public void ContainsForbiddenCharacters_StringNotContainsForbiddenCharacters(string input) {
            var actual = GeneralUtils.ContainsForbiddenCharacters(input);

            Assert.False(actual);
        }
        // [Theory]
        // [InlineData(" Hello world")]
        // [InlineData(" Hey313")]
        // [InlineData(" YOo4015rujafAJFA")]
        // public void ContainsOnlyAlphaNumericCharacters_StringContainsOnlyAlphaNumericCharacters_ShouldReturnTrue(string value) {
        //     var acutal = GeneralUtils.ContainsOnlyAlphaNumericCharacters(value);

        //     Assert.True(acutal);
        // }

        // [Theory]
        // [InlineData(" Hey!")]
        // [InlineData("#    Hello Wordl")]
        // [InlineData("^YO^")]
        // public void ContainsOnlyAlphaNumericCharacters_StringDoesNotContainOnlyAlphaNumericCharacters_ShouldReturnFalse(string value) {
        //     var acutal = GeneralUtils.ContainsOnlyAlphaNumericCharacters(value);

        //     Assert.False(acutal);
        // }
    }
}