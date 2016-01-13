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
    public class TestCsvWriter
    {
        [Test]
        public void Construct_GivenNullFolder_ShouldThrowANE()
        {
            //---------------Set up test pack-------------------
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var exception = Assert.Throws<ArgumentNullException>(() =>new CsvWriter(null));
            //---------------Test Result -----------------------
            Assert.AreEqual("folder", exception.ParamName);
        }
        
        [Test]
        public void Save_GivenFileNameAndLine_ShouldCallAppendLineWithFileNameAndLine()
        {
            //---------------Set up test pack-------------------
            var folder = Substitute.For<IFolder>();
            var csvWriter = CreateCsvWriter(folder);
            var line = "line";
            var fileName = "file.csv";
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            csvWriter.Save(fileName, line);
            //---------------Test Result -----------------------
            folder.Received().AppendLine(fileName, line);
        }

        private static CsvWriter CreateCsvWriter(IFolder folder = null)
        {
            folder = folder ?? Substitute.For<IFolder>();
            return new CsvWriter(folder);
        }
    }
}
