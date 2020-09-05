using JsonDatabase.Utils;
using Xunit;

namespace JsonDatabase.Tests.Utils {
    public class GeneralUtilsTests {
        [Theory]
        [InlineData("4", 4)]
        [InlineData("\"Hello world\"", "Hello world")]
        [InlineData("false", false)]
        [InlineData("FALSE", false)]
        [InlineData("true", true)]
        [InlineData("TRUE", true)]
        public void TransformStringValueToRealValue_ValidString_ShouldReturnCorrespondingValue(string value, object expectedValue) {
            var actual = GeneralUtils.TransformStringValueToRealValue(value);

            Assert.Equal(actual, expectedValue);
        }
    }
}