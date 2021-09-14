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
        [InlineData("\n", 0)]
        public void Add_EmptyOrWhiteSpace_Zero(string emptyString, int expected)
        {
            // arrange

            // act
            var result = calculator.Add(emptyString);

            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_OneNumber_ReturnsTheSameNumber()
        {
            // arrange
            var oneNumber = "3";
            var expected = 3;

            // act
            var result = calculator.Add(oneNumber);

            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_TwoNumber_ReturnsTheirSum()
        {
            // arrange
            var twoNumber = "12,2";
            var expected = 14;

            // act
            var result = calculator.Add(twoNumber);

            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_NewLine_NewLineAsSeparator()
        {
            // arrange
            var newLine = "1,2\n3";
            var expected = 6;

            // act
            var result = calculator.Add(newLine);

            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_DifferentDelimiter_SumNumbers()
        {
            // arrange
            var differentDelimiter = "//;;;\n1;;;2";
            var expected = 3;

            // act
            var result = calculator.Add(differentDelimiter);

            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_Negative_Throws()
        {
            // arrange
            var negative = "-2";

            // act

            // assert
            var actual = Assert.Throws<ApplicationException>(() => calculator.Add(negative));
            Assert.Equal("Negatives not allowed: -2", actual.Message);
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

        [Fact]
        public void Add_Event_EventCall()
        {
            // arrange
            int giveResult = 0;

            calculator.AddOccured += delegate (string input, int result)
            {
                giveResult = result;
            };

            // act
            var sum = calculator.Add("1");

            // assert
            Assert.Equal(giveResult, sum);
        }

        [Fact]
        public void Add_NumbersBiggerThan1000_Ignored()
        {
            // arrange
            var numbersBiggerThan1000 = "1005, 3\n10002\n5";
            var expected = 8;

            // act
            var result = calculator.Add(numbersBiggerThan1000);

            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_OtherFormatDelimiters_Supported()
        {
            // arrange
            var otherFormatDelimiters = "//[***]\n1***2***3";
            var expected = 6;

            // act
            var result = calculator.Add(otherFormatDelimiters);

            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_MultipleDelimiters_Supported()
        {
            // arrange
            var multipleDelimiters = "//[*][%]\n1*2%3";
            var expected = 6;

            // act
            var result = calculator.Add(multipleDelimiters);

            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_MultipleDelimitersWithLengthLongerThanOneChar_Supported()
        {
            // arrange
            var multipleDelimiters = "//[**][%%]\n1**2%%3";
            var expected = 6;

            // act
            var result = calculator.Add(multipleDelimiters);

            // assert
            Assert.Equal(expected, result);
        }
    }
}
