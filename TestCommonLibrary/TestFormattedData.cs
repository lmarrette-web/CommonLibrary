using System;
using System.Management.Instrumentation;
using CommonLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCommonLibrary
{
    [TestClass]
    public class TestFormattedData
    {
        [TestMethod]
        public void AddLeadingZerosReturnsPaddedInputIfLengthLessThanLengthParameter()
        {
            var fd = new FormattedData();
            string inputValue = "4123";
            string returnValue = fd.AddLeadingZeros(inputValue, 10);
            string expectedValue = "0000004123";
            
            Assert.AreEqual(expectedValue, returnValue);
        }

        [TestMethod]
        public void AddLeadingZerosReturnsInputIfLengthMatchesLengthParameter()
        {
            var    fd            = new FormattedData();
            string inputValue    = "1234564123";
            string returnValue   = fd.AddLeadingZeros(inputValue, 10);
            string expectedValue = "1234564123";

            Assert.AreEqual(expectedValue, returnValue);
        }

        [TestMethod]
        public void AddLeadingZerosReturnsInputIfLengthGreaterThanLengthParameter()
        {
            var    fd            = new FormattedData();
            string inputValue    = "1234564123888";
            string returnValue   = fd.AddLeadingZeros(inputValue, 10);
            string expectedValue = "1234564123888";

            Assert.AreEqual(expectedValue, returnValue);
        }

        [TestMethod]
        public void AddLeadingZerosReturnsZerosIfInputValueBlank()
        {
            var    fd            = new FormattedData();
            string inputValue = string.Empty;
            string returnValue   = fd.AddLeadingZeros(inputValue, 10);
            string expectedValue = "0000000000";

            Assert.AreEqual(expectedValue, returnValue);
        }

        [TestMethod]
        public void ReturnCityFromCityStateZipReturnsCityWhenCommaIsInCsz()
        {
            var fd = new FormattedData();
            string inputValue = "New York, NY 10037";
            var addr = fd.ParseCityStateZip(inputValue);
            string expectedValue = "New York";

            Assert.AreEqual(expectedValue, addr.City);
        }

        [TestMethod]
        public void ReturnInputValueFromCityStateZipReturnsCityWhenCommaIsNotInCsz()
        {
            var fd = new FormattedData();
            string inputValue = "Statesboro GA 30478";
            var addr = fd.ParseCityStateZip(inputValue);
            string expectedValue = "Statesboro GA 30478";

            Assert.AreEqual(expectedValue, inputValue);
        }

        [TestMethod]
        public void ReturnInputValueFromCityStateZipReturnsStateWhenCommaIsInCsz()
        {
            var    fd            = new FormattedData();
            string inputValue    = "Statesboro, GA 30478";
            var    addr          = fd.ParseCityStateZip(inputValue);
            string expectedValue = "GA";

            Assert.AreEqual(expectedValue, addr.State);
        }

        [TestMethod]
        public void ReturnInputValueFromCityStateZipReturnsZipCodeWhenCommaIsInCsz()
        {
            var    fd            = new FormattedData();
            string inputValue    = "Statesboro, GA 30478";
            var    addr          = fd.ParseCityStateZip(inputValue);
            string expectedValue = "30478";

            Assert.AreEqual(expectedValue, addr.PostalCode);
        }

        [TestMethod]
        public void ReturnInputValueFromCityStateZipReturnsZipCodeWhenCommaIsInCszAnd9DigitZip()
        {
            var    fd            = new FormattedData();
            string inputValue    = "Statesboro, GA 30478-1234";
            var    addr          = fd.ParseCityStateZip(inputValue);
            string expectedValue = "30478-1234";

            Assert.AreEqual(expectedValue, addr.PostalCode);
        }

        [TestMethod]
        public void ReturnInputValueFromCityStateZipReturnsBlankWhenInputIsBlank()
        {
            var    fd            = new FormattedData();
            string inputValue    = String.Empty;
            var    addr          = fd.ParseCityStateZip(inputValue);
            string expectedValue = string.Empty;

            Assert.AreEqual(expectedValue, "");
        }
    }
}
