using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CSVKata
{
    [TestFixture]
    public class TestDataCleaner
    {
        [Test]
        public void Capture_Given5CustomersWith1Duplicate_ShouldReturn4()
        {
            //---------------Set up test pack-------------------
            var customers = new List<Customer>
            {
                new Customer {Name = "Bob", ContactNumber = "112"},
                new Customer {Name = "Jim", ContactNumber = "883"},
                new Customer {Name = "Bob", ContactNumber = "112"},
                new Customer {Name = "Jim", ContactNumber = "777"},
                new Customer {Name = "Joe", ContactNumber = "145"},
            };
            var dataCleaner = new DataCleaner();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var uniqueEntries = dataCleaner.RemoveDuplicates(customers);
            //---------------Test Result -----------------------
            Assert.AreEqual(4, uniqueEntries.Count);
        }

        [Test]
        public void Capture_Given5CustomersWith0Duplicates_ShouldReturnOriginalList()
        {
            //---------------Set up test pack-------------------
            var customers = new List<Customer>
            {
                new Customer {Name = "Bob", ContactNumber = "112"},
                new Customer {Name = "Jim", ContactNumber = "883"},
                new Customer {Name = "Bob", ContactNumber = "982"},
                new Customer {Name = "Jim", ContactNumber = "777"},
                new Customer {Name = "Joe", ContactNumber = "145"},
            };
            var dataCleaner = new DataCleaner();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var uniqueEntries = dataCleaner.RemoveDuplicates(customers);
            //---------------Test Result -----------------------
            CollectionAssert.AreEqual(customers, uniqueEntries);
        }
    }
}
