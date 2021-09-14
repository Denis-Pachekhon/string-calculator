﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
        private StringCalculator calculator;

        [TestInitialize]
        public void TestInitialize()
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

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void Add_Negative_Throws()
        {
            // arrange
            var negative = "-2";

            // act
            var result = calculator.Add(negative);

            // assert
        }

        [TestMethod]
        public void GetCalledCount_Call2Add_Called2Add()
        {
            // arrange
            var expected = 2;

            // act
            calculator.Add("");
            calculator.Add("");
            var count = calculator.GetCalledCount();

            // assert
            Assert.AreEqual(expected, count);
        }

        [TestMethod]
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
            Assert.AreEqual(giveResult, sum);
        }

        [TestMethod]
        public void Add_NumbersBiggerThan1000_Ignored()
        {
            var numbersBiggerThan1000 = "1005, 3\n10002\n5";
            var expected = 8;

            // act
            var result = calculator.Add(numbersBiggerThan1000);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_OtherFormatDelimiters_Supported()
        {
            var otherFormatDelimiters = "//[***]\n1***2***3";
            var expected = 6;

            // act
            var result = calculator.Add(otherFormatDelimiters);

            // assert
            Assert.AreEqual(expected, result);
        }
    }
}
