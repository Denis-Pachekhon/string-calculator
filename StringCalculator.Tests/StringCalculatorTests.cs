using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
        private static StringCalculator calculator;

        [ClassInitialize]
        public static void ClassInitialize(TestContext textContext)
        {
            calculator = new StringCalculator();
        }

        [TestMethod]
        public void Add_EmptyString_Zero()
        {
            // arrange
            var emptyString = "";
            var expected = 0;

            // act
            var result = calculator.Add(emptyString);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_OneNumber_ReturnsTheSameNumber()
        {
            // arrange
            var oneNumber = "3";
            var expected = 3;

            // act
            var result = calculator.Add(oneNumber);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_TwoNumber_ReturnsTheirSum()
        {
            // arrange
            var twoNumber = "12,2";
            var expected = 14;

            // act
            var result = calculator.Add(twoNumber);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_NewLine_NewLineAsSeparator()
        {
            // arrange
            var newLine = "1,2\n3";
            var expected = 6;

            // act
            var result = calculator.Add(newLine);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_NewLine_Zero()
        {
            // arrange
            var newLine = "\n";
            var expected = 0;

            // act
            var result = calculator.Add(newLine);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_DifferentDelimiter_SumNumbers()
        {
            // arrange
            var differentDelimiter = "//;;;\n1;;;2";
            var expected = 3;

            // act
            var result = calculator.Add(differentDelimiter);

            // assert
            Assert.AreEqual(expected, result);
        }
    }
}
