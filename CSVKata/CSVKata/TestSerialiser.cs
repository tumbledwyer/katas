using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CSVKata
{
    [TestFixture]
    public class TestSerialiser
    {
        [Test]
        public void SerialiseCustomer_GivenEmptyName_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            var customer = new Customer { Name = "", ContactNumber = "083" };
            var serialiser = CreateSerialiser();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var exception = Assert.Throws<ArgumentNullException>(() => serialiser.SerialiseCustomer(customer));
            //---------------Test Result -----------------------
            Assert.AreEqual("Name", exception.ParamName);
        }

        [Test]
        public void SerialiseCustomer_GivenEmptyContactNumber_ShouldThrowException()
        {
            //---------------Set up test pack-------------------
            var customer = new Customer { Name = "Bob", ContactNumber = "" };
            var serialiser = CreateSerialiser();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var exception = Assert.Throws<ArgumentNullException>(() => serialiser.SerialiseCustomer(customer));
            //---------------Test Result -----------------------
            Assert.AreEqual("ContactNumber", exception.ParamName);
        }

        [Test]
        public void SerialiseCustomer_GivenNameAndContactNumber_ShouldNotThrowException()
        {
            //---------------Set up test pack-------------------
            var customer = new Customer { Name = "Bob", ContactNumber = "085" };
            var serialiser = CreateSerialiser();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            Assert.DoesNotThrow(() => serialiser.SerialiseCustomer(customer));
        }

        [Test]
        public void SerialiseCustomer_GivenNameAndNumber_ShouldReturnConcatenatedStringsWithCommas()
        {
            //---------------Set up test pack-------------------
            var customer = new Customer { Name = "Bob", ContactNumber = "085" };
            const string expectedResult = "Bob,085\n";
            var serialiser = CreateSerialiser();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var serialised = serialiser.SerialiseCustomer(customer);
            //---------------Test Result -----------------------
            Assert.AreEqual(expectedResult, serialised);
        }

        private static Serialiser CreateSerialiser()
        {
            return new Serialiser();
        }
    }
}
