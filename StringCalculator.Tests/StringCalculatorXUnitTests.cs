
using Xunit;

namespace StringCalculator.Tests
{
    public class StringCalculatorXUnitTests
    {
        private StringCalculator calculator;

        public StringCalculatorXUnitTests()
        {
            calculator = new StringCalculator();
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData(" ", 0)]
        public void Add_EmptyOrWhiteSpace_Zero(string emptyString, int expected)
        {
            // arrange

            // act
            var result = calculator.Add(emptyString);

            // assert
            Assert.Equal(expected, result);
        }
    }
}
