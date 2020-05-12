// Created by:  Lee Marrette
// Date:  11/15/2018
// Solution:  ProviderPayLoad
// File:  DateHelper.cs

using System;

namespace CommonLibrary
{
    public class DateHelper
    {
        /// <summary>
        /// Returns the last day of the month prior to the current month
        /// </summary>
        /// <returns></returns>
        public DateTime LastDayOfLastMonth()
        {
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            return new DateTime(currentYear, currentMonth, 1).AddDays(-1);
        }
    }
}