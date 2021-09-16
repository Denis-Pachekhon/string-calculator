
using System;
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

        [Theory]
        [InlineData("1\n3", 4)]
        [InlineData("1,2\n3", 6)]
        public void Add_NewLine_NewLineAsSeparator(string input, int expected)
        {
            // arrange

            // act
            var result = calculator.Add(input);

            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//;;;\n1;;;2", 3)]
        public void Add_DifferentDelimiter_Supported(string input, int expected)
        {
            // arrange

            // act
            var result = calculator.Add(input);

            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("-2", "Negatives not allowed: -2")]
        [InlineData("-2,-3", "Negatives not allowed: -2, -3")]
        public void Add_Negative_Throws(string input, string expected)
        {
            // arrange

            // act

            // assert
            var actual = Assert.Throws<ApplicationException>(() => calculator.Add(input));
            Assert.Equal(expected, actual.Message);
        }

        [Fact]
        public void GetCalledCount_Call2Add_Called2Add()
        {
            // arrange
            var expected = 2;

            // act
            calculator.Add("");
            calculator.Add("");
            var count = calculator.GetCalledCount();

            // assert
            Assert.Equal(expected, count);
        }
    }
}
