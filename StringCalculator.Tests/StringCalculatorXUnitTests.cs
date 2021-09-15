
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
        public void Add_EmptyOrWhiteSpace_Zero(string input, int expected)
        {
            // arrange

            // act
            var result = calculator.Add(input);

            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        public void Add_OneNumber_ReturnsTheSameNumber(string input, int expected)
        {
            // arrange

            // act
            var result = calculator.Add(input);

            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,3", 4)]
        [InlineData("2, 2, 3", 7)]
        public void Add_TwoNumber_ReturnsTheirSum(string input, int expected)
        {
            // arrange

            // act
            var result = calculator.Add(input);

            // assert
            Assert.Equal(expected, result);
        }
    }
}
