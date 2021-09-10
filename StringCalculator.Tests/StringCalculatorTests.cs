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
            var emptyString = String.Empty;
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
    }
}
