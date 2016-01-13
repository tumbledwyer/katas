using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace CSVKata
{
    [TestFixture]
    public class TestCustomerCapturer
    {
        [Test]
        public void Construct_GivenNullCSVWriter_ShouldThrowANE()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var exception = Assert.Throws<ArgumentNullException>((() => new CustomerCapturer(null, Substitute.For<ISerialiser>(), Substitute.For<IDataCleaner>())));
            //---------------Test Result -----------------------
            Assert.AreEqual("csvWriter", exception.ParamName);
        }

        [Test]
        public void Construct_GivenNullSerialiser_ShouldThrowANE()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var exception = Assert.Throws<ArgumentNullException>((() => new CustomerCapturer(Substitute.For<ICsvWriter>(), null, Substitute.For<IDataCleaner>())));
            //---------------Test Result -----------------------
            Assert.AreEqual("serialiser", exception.ParamName);
        }

        [Test]
        public void Capture_GivenCustomer_ShouldSerialise()
        {
            //---------------Set up test pack-------------------
            var serialiser = Substitute.For<ISerialiser>();
            var customerCapturer = CreateCustomerCapturer(serialiser: serialiser);
            var customer = new Customer();
            var customers = new List<Customer> {customer};
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            customerCapturer.Capture(customers, "", 10);
            //---------------Test Result -----------------------
            serialiser.Received().SerialiseCustomer(customer);
        }

        [Test]
        public void Capture_GivenFileNameShouldSaveWithFileNameWithNumber()
        {
            //---------------Set up test pack-------------------
            var csvWriter = Substitute.For<ICsvWriter>();
            var customer = new Customer();
            var serialiser = Substitute.For<ISerialiser>();
            serialiser.SerialiseCustomer(customer).Returns("Bob");
            var customerCapturer = CreateCustomerCapturer(csvWriter, serialiser);
            var customers = new List<Customer> {customer};
            const string fileName = "stuff";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            customerCapturer.Capture(customers, fileName, 10);
            //---------------Test Result -----------------------
            csvWriter.Received().Save(fileName+".1", Arg.Any<string>());
        }

        [Test]
        public void Capture_GivenSerialiedCustomerShouldSave()
        {
            //---------------Set up test pack-------------------
            var csvWriter = Substitute.For<ICsvWriter>();
            var customer = new Customer();
            var customers = new List<Customer> {customer};
            var serialiser = Substitute.For<ISerialiser>();
            const string serialisedCustomer = "Bob,083";
            serialiser.SerialiseCustomer(customer).Returns(serialisedCustomer);
            var customerCapturer = CreateCustomerCapturer(csvWriter, serialiser);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            customerCapturer.Capture(customers, "", 10);
            //---------------Test Result -----------------------
            csvWriter.Received().Save(Arg.Any<string>(), serialisedCustomer);
        }


        [Test]
        public void Capture_GivenListOf3Customers_ShouldSerialise3Times()
        {
            //---------------Set up test pack-------------------
            var serialiser = Substitute.For<ISerialiser>();
            var customerCapturer = CreateCustomerCapturer(serialiser: serialiser);
            var customers = CreateCustomers(3);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            customerCapturer.Capture(customers, "", 10);
            //---------------Test Result -----------------------
            serialiser.Received(3).SerialiseCustomer(Arg.Any<Customer>());
        }

        [Test]
        public void Capture_GivenListOf3Customers_ShouldSave3Times()
        {
            //---------------Set up test pack-------------------
            var csvWriter = Substitute.For<ICsvWriter>();

            var customerCapturer = CreateCustomerCapturer(csvWriter);
            var customers = CreateCustomers(3);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            customerCapturer.Capture(customers, "", 10);
            //---------------Test Result -----------------------
            csvWriter.Received(3).Save(Arg.Any<string>(), Arg.Any<string>());
        }

        [Test]
        public void Capture_GivenListOf11Customers_ShouldSave10TimesAndOnceWithFirstAppendedFilename()
        {
            //---------------Set up test pack-------------------
            var csvWriter = Substitute.For<ICsvWriter>();
            var customerCapturer = CreateCustomerCapturer(csvWriter);
            var customers = CreateCustomers(11);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            customerCapturer.Capture(customers, "stuff", 10);
            //---------------Test Result -----------------------
            csvWriter.Received(10).Save("stuff.1", Arg.Any<string>());
            csvWriter.Received(1).Save("stuff.2", Arg.Any<string>());
        }

        [Test]
        public void Capture_GivenListOf34Customers_ShouldCreate4Files()
        {
            //---------------Set up test pack-------------------
            var csvWriter = Substitute.For<ICsvWriter>();
            var customerCapturer = CreateCustomerCapturer(csvWriter);
            var customers = CreateCustomers(34);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            customerCapturer.Capture(customers, "stuff", 10);
            //---------------Test Result -----------------------
            csvWriter.Received(10).Save("stuff.1", Arg.Any<string>());
            csvWriter.Received(10).Save("stuff.2", Arg.Any<string>());
            csvWriter.Received(10).Save("stuff.3", Arg.Any<string>());
            csvWriter.Received(4).Save("stuff.4", Arg.Any<string>());
        }

        [Test]
        public void Capture_GivenBatchSizeOf50AndListOf125Customers_ShouldCreate3Files()
        {
            //---------------Set up test pack-------------------
            var csvWriter = Substitute.For<ICsvWriter>();
            var customerCapturer = CreateCustomerCapturer(csvWriter);
            var customers = CreateCustomers(125);
            const int batchSize = 50;
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            customerCapturer.Capture(customers, "stuff", batchSize);
            //---------------Test Result -----------------------
            csvWriter.Received(50).Save("stuff.1", Arg.Any<string>());
            csvWriter.Received(50).Save("stuff.2", Arg.Any<string>());
            csvWriter.Received(25).Save("stuff.3", Arg.Any<string>());
        }

        private static List<Customer> CreateCustomers(int count)
        {
            var customers = new List<Customer>();
            for (var i = 0; i < count; i++)
            {
                customers.Add(new Customer
                {
                    Name = $"Bob{i}",
                    ContactNumber = $"079{i}"
                });
            }
            return customers;
        }


        private static CustomerCapturer CreateCustomerCapturer(ICsvWriter csvWriter = null, ISerialiser serialiser = null, IDataCleaner dataCleaner = null)
        {
            csvWriter = csvWriter ?? Substitute.For<ICsvWriter>();
            serialiser = serialiser ?? Substitute.For<ISerialiser>();
            dataCleaner = dataCleaner ?? new DataCleaner();
            return new CustomerCapturer(csvWriter, serialiser, dataCleaner);
        }

    }
}
