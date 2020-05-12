using System;
using CommonLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCommonLibrary
{
    [TestClass]
    public class TestDateHelper
    {
        [TestMethod]
        public void LastDayOfLastMonthReturnsCorrectDate()
        {
            DateHelper dateHelper = new DateHelper();
            DateTime calculatedEndDate = dateHelper.LastDayOfLastMonth();
            DateTime expectedDate = new DateTime(2018, 10, 31);

            Assert.AreEqual(expectedDate, calculatedEndDate);
        }
    }
}
