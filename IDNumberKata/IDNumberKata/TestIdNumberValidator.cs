using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace IDNumberKata
{
    [TestFixture]
    public class TestIdNumberValidator
    {

        [Test]
        public void ExtractIDParts_GivenIDNumberIn1900s_ShouldReturnDateOfBirthIn1900s()
        {
            //---------------Set up test pack-------------------
            const string idNumber = "9208155034085";
            const string expectedDate = "15-08-1992";
            var idNumberValidator = Create();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var idParts = idNumberValidator.ExtractIDParts(idNumber);
            //---------------Test Result -----------------------
            Assert.AreEqual(expectedDate, idParts.DOB);
        }

        [Test]
        public void ExtractIDParts_GivenIDNumberIn2000s_ShouldReturnDateOfBirthIn2000s()
        {
            //---------------Set up test pack-------------------
            const string idNumber = "0108155034085";
            const string expectedDate = "15-08-2001";
            var idNumberValidator = Create();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var idParts = idNumberValidator.ExtractIDParts(idNumber);
            //---------------Test Result -----------------------
            Assert.AreEqual(expectedDate, idParts.DOB);
        }

        [Test]
        public void ExtractIDParts_GivenGenderIndicatorIs3_ShouldReturnFemale()
        {
            //---------------Set up test pack-------------------
            const string idNumber = "0108153034085";
            const string expectedGender = "Female";
            var idNumberValidator = Create();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var idParts = idNumberValidator.ExtractIDParts(idNumber);
            //---------------Test Result -----------------------
            Assert.AreEqual(expectedGender, idParts.Gender);
        }

        [Test]
        public void ExtractIDParts_GivenGenderIndicatorIs6_ShouldReturnMale()
        {
            //---------------Set up test pack-------------------
            const string idNumber = "0108156034085";
            const string expectedGender = "Male";
            var idNumberValidator = Create();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var idParts = idNumberValidator.ExtractIDParts(idNumber);
            //---------------Test Result -----------------------
            Assert.AreEqual(expectedGender, idParts.Gender);
        }

        [Test]
        public void ExtractIDParts_GivenCitizenshipStatusIs0_ShouldReturnSA()
        {
            //---------------Set up test pack-------------------
            const string idNumber = "0108156034085";
            const string expectedCitizenship = "SA";
            var idNumberValidator = Create();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var idParts = idNumberValidator.ExtractIDParts(idNumber);
            //---------------Test Result -----------------------
            Assert.AreEqual(expectedCitizenship, idParts.Citizenship);
        }

        [Test]
        public void ExtractIDParts_GivenCitizenshipStatusIs1_ShouldReturnOther()
        {
            //---------------Set up test pack-------------------
            const string idNumber = "0108156034185";
            const string expectedCitizenship = "Other";
            var idNumberValidator = Create();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var idParts = idNumberValidator.ExtractIDParts(idNumber);
            //---------------Test Result -----------------------
            Assert.AreEqual(expectedCitizenship, idParts.Citizenship);
        }

        [Test]
        public void ValidateID_GivenNumber_ShouldGetCheckSum()
        {
            //---------------Set up test pack-------------------
            const string idNumber = "8503285167081";
            var checkSumHelper = Substitute.For<ICheckSumHelper>();
            var idNumberValidator = Create(checkSumHelper);
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            idNumberValidator.ValidateID(idNumber);
            //---------------Test Result -----------------------

            Assert.Fail("Test Not Yet Implemented");
        }

        private static IdNumberValidator Create(ICheckSumHelper checkSumHelper = null)
        {
            return new IdNumberValidator(checkSumHelper);
        }
    }

    public interface ICheckSumHelper
    {
    }
}
