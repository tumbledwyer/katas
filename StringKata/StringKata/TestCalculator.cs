using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StringKata
{
    [TestFixture]
    public class TestCalculator
    {
        [Test]
        public void Add_GivenTheEmptyString_ShouldReturn0()
        {
            //---------------Set up test pack-------------------
            const string input = "";
            const int expected = 0;
            var calculator = new Calculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_Given1Digit_ShouldReturnIntegerValueOfDigit()
        {
            //---------------Set up test pack-------------------
            const string input = "1";
            const int expected = 1;
            var calculator = new Calculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_Given2_ShouldReturnIntegerValue2()
        {
            //---------------Set up test pack-------------------
            const string input = "2";
            const int expected = 2;
            var calculator = new Calculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_Given3_ShouldReturnIntegerValue3()
        {
            //---------------Set up test pack-------------------
            const string input = "3";
            const int expected = 3;
            var calculator = new Calculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_Given2Digits_ShouldReturnTheSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1,2";
            const int expected = 3;
            var calculator = new Calculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_Given3DigitsWithCommaDelimiter_ShouldReturnTheSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1,2,3";
            const int expected = 6;
            var calculator = new Calculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_Given3DigitsWithNewLineDelimiter_ShouldReturnTheSum()
        {
            //---------------Set up test pack-------------------
            const string input = "1\n2,3";
            const int expected = 6;
            var calculator = new Calculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_Given3DigitsWithCustomDelimiter_ShouldReturnTheSum()
        {
            //---------------Set up test pack-------------------
            const string input = "//;\n1;2;3";
            const int expected = 6;
            var calculator = new Calculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_GivenNegativeNumber_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            const string input = "-1,-2,3";
            const string expected = "negatives not allowed: -1-2";
            var calculator = new Calculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var exception = Assert.Throws<Exception>(() => calculator.Add(input));
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, exception.Message);
        }

        [Test]
        public void Add_GivenDigitsGreaterthan1000_ShouldIgnoreTheDigit()
        {
            //---------------Set up test pack-------------------
            const string input = "3,1003";
            const int expected = 3;
            var calculator = new Calculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = calculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

    }
}
