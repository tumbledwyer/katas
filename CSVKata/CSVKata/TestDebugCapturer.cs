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
    public class TestDebugCapturer
    {
        [Test]
        public void CaptureDebug_GivenBatchSize_ShouldCallCaptureForRegularBatch()
        {
            //---------------Set up test pack-------------------
            var customerCapturer = Substitute.For<ICustomerCapturer>();
            var debugCapturer = new DebugCapturer(customerCapturer);
            var customers = CreateCustomers(50);
            const int normalBatchSize = 150000;
            const int debugBatchSize = 20;
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            debugCapturer.CaptureDebug(customers, "stuff", normalBatchSize, debugBatchSize);
            //---------------Test Result -----------------------
            customerCapturer.Received().Capture(customers, "stuff", normalBatchSize);
        }

        [Test]
        public void CaptureDebug_GivenDebugBatchSize_ShouldCallCaptureForDebugBatch()
        {
            //---------------Set up test pack-------------------
            var customerCapturer = Substitute.For<ICustomerCapturer>();
            var debugCapturer = new DebugCapturer(customerCapturer);
            var customers = CreateCustomers(50);
            const int normalBatchSize = 150000;
            const int debugBatchSize = 20;
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            debugCapturer.CaptureDebug(customers, "stuff", normalBatchSize, debugBatchSize);
            //---------------Test Result -----------------------
            customerCapturer.Received().Capture(customers, "stuff.debug", debugBatchSize);
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
    }
}
