using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Fizzbuzz
{
    [TestFixture]
    public class TestFizzBuzz
    {
        [Test]
        public void FizzBuzzer_Given1_ShouldReturn1()
        {
            //---------------Set up test pack-------------------
            var fizzBuzz = new FizzBuzz();
            const int input = 1;
            const string expected = "1";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = fizzBuzz.FizzBuzzer(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FizzBuzzer_Given2_ShouldReturn2()
        {
            //---------------Set up test pack-------------------
            var fizzBuzz = new FizzBuzz();
            const int input = 2;
            const string expected = "2";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = fizzBuzz.FizzBuzzer(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FizzBuzzer_Given3_ShouldReturnFizz()
        {
            //---------------Set up test pack-------------------
            var fizzBuzz = new FizzBuzz();
            const int input = 3;
            const string expected = "Fizz";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = fizzBuzz.FizzBuzzer(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FizzBuzzer_Given4_ShouldReturn4()
        {
            //---------------Set up test pack-------------------
            var fizzBuzz = new FizzBuzz();
            const int input = 4;
            const string expected = "4";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = fizzBuzz.FizzBuzzer(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FizzBuzzer_Given5_ShouldReturnBuzz()
        {
            //---------------Set up test pack-------------------
            var fizzBuzz = new FizzBuzz();
            const int input = 5;
            const string expected = "Buzz";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = fizzBuzz.FizzBuzzer(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FizzBuzzer_Given6_ShouldReturnFizz()
        {
            //---------------Set up test pack-------------------
            var fizzBuzz = new FizzBuzz();
            const int input = 6;
            const string expected = "Fizz";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = fizzBuzz.FizzBuzzer(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FizzBuzzer_Given9_ShouldReturnFizz()
        {
            //---------------Set up test pack-------------------
            var fizzBuzz = new FizzBuzz();
            const int input = 9;
            const string expected = "Fizz";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = fizzBuzz.FizzBuzzer(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FizzBuzzer_Given10_ShouldReturnBuzz()
        {
            //---------------Set up test pack-------------------
            var fizzBuzz = new FizzBuzz();
            const int input = 10;
            const string expected = "Buzz";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = fizzBuzz.FizzBuzzer(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FizzBuzzer_Given15_ShouldReturnFizzBuzz()
        {
            //---------------Set up test pack-------------------
            var fizzBuzz = new FizzBuzz();
            const int input = 15;
            const string expected = "FizzBuzz";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = fizzBuzz.FizzBuzzer(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FizzBuzzer_Given20_ShouldReturnBuzz()
        {
            //---------------Set up test pack-------------------
            var fizzBuzz = new FizzBuzz();
            const int input = 20;
            const string expected = "Buzz";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = fizzBuzz.FizzBuzzer(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FizzBuzzer_Given30_ShouldReturnFizzBuzz()
        {
            //---------------Set up test pack-------------------
            var fizzBuzz = new FizzBuzz();
            const int input = 30;
            const string expected = "FizzBuzz";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = fizzBuzz.FizzBuzzer(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FizzBuzzer_Given75_ShouldReturnFizzBuzz()
        {
            //---------------Set up test pack-------------------
            var fizzBuzz = new FizzBuzz();
            const int input = 75;
            const string expected = "FizzBuzz";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var result = fizzBuzz.FizzBuzzer(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, result);
        }
    }
}
