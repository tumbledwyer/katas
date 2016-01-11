using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AgeCalculator
{
    [TestFixture]
    public class TestAgeCalculator
    {
        private readonly AgeCalculator _ageCalculator = new AgeCalculator();

        [Test]
        public void GetAge_GivenTheDayYouWereBorn_ShouldReturn0()
        {
            //---------------Set up test pack-------------------
            var birthDate = new DateTime(1985, 3, 28);
            var chosenDate = new DateTime(1985, 3, 28);
            const int expectedAge = 0;
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var age = _ageCalculator.GetAge(birthDate, chosenDate);
            //---------------Test Result -----------------------
            Assert.AreEqual(expectedAge, age);
        }

        [Test]
        public void GetAge_GivenFirstBirthday_ShouldReturn1()
        {
            //---------------Set up test pack-------------------
            var birthDate = new DateTime(1985, 3, 28);
            var chosenDate = new DateTime(1986, 3, 28);
            const int expectedAge = 1;
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var age = _ageCalculator.GetAge(birthDate, chosenDate);
            //---------------Test Result -----------------------
            Assert.AreEqual(expectedAge, age);
        }

        [Test]
        public void GetAge_GivenMonthBeforeThirdBirthdayInTheSameYear_ShouldReturn2()
        {
            //---------------Set up test pack-------------------
            var birthDate = new DateTime(1985, 3, 28);
            var chosenDate = new DateTime(1988, 2, 28);
            const int expectedAge = 2;
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var age = _ageCalculator.GetAge(birthDate, chosenDate);
            //---------------Test Result -----------------------
            Assert.AreEqual(expectedAge, age);
        }

        [Test]
        public void GetAge_GivenMonthAfterThirdBirthdayInTheSameYear_ShouldReturn3()
        {
            //---------------Set up test pack-------------------
            var birthDate = new DateTime(1985, 1, 28);
            var chosenDate = new DateTime(1988, 2, 28);
            const int expectedAge = 3;
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var age = _ageCalculator.GetAge(birthDate, chosenDate);
            //---------------Test Result -----------------------
            Assert.AreEqual(expectedAge, age);
        }

        [Test]
        public void GetAge_GivenDayBeforeThirdBirthdayInTheSameMonthAndYear_ShouldReturn2()
        {
            //---------------Set up test pack-------------------
            var birthDate = new DateTime(1985, 3, 28);
            var chosenDate = new DateTime(1988, 3, 27);
            const int expectedAge = 2;
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var age = _ageCalculator.GetAge(birthDate, chosenDate);
            //---------------Test Result -----------------------
            Assert.AreEqual(expectedAge, age);
        }

        [Test]
        public void GetAge_GivenDateBeforeBirthday_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            var birthDate = new DateTime(1985, 3, 28);
            var chosenDate = new DateTime(1984, 3, 27);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var exception = Assert.Throws<Exception>(() => _ageCalculator.GetAge(birthDate, chosenDate));
            //---------------Test Result -----------------------
            Assert.AreEqual("Age out of range", exception.Message);
        }

        [Test]
        public void GetAge_GivenALeaplingOn3rdBirtday_ShouldReturn3()
        {
            //---------------Set up test pack-------------------
            var birthDate = new DateTime(1984, 2, 29);
            var chosenDate = new DateTime(1987, 2, 28);
            const int expectedAge = 3;
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var age = _ageCalculator.GetAge(birthDate, chosenDate);
            //---------------Test Result -----------------------
            Assert.AreEqual(expectedAge, age);
        }

        [Test]
        public void GetAge_GivenALeaplingOn28thFebOf4thYear_ShouldReturn3()
        {
            //---------------Set up test pack-------------------
            var birthDate = new DateTime(1984, 2, 29);
            var chosenDate = new DateTime(1988, 2, 28);
            const int expectedAge = 3;
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var age = _ageCalculator.GetAge(birthDate, chosenDate);
            //---------------Test Result -----------------------
            Assert.AreEqual(expectedAge, age);
        }

        [Test]
        public void GetAge_GivenALeaplingOn29thFebOf4thYear_ShouldReturn4()
        {
            //---------------Set up test pack-------------------
            var birthDate = new DateTime(1984, 2, 29);
            var chosenDate = new DateTime(1988, 2, 29);
            const int expectedAge = 4;
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var age = _ageCalculator.GetAge(birthDate, chosenDate);
            //---------------Test Result -----------------------
            Assert.AreEqual(expectedAge, age);
        }

    }
}
