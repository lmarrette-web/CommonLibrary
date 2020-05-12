// Created by:  Lee Marrette
// Date:  11/14/2018
// Solution:  ProviderPayLoad
// File:  FormattedData.cs

using System;

namespace CommonLibrary
{
    /// <summary>
    ///     Routines to handle common formatting issues
    /// </summary>
    public class FormattedData
    {
        public string AddLeadingZeros(string inputValue,
                                      int    length)
        {
            var outputValue = string.Empty;
            if (inputValue.Length >= length) return inputValue;
            outputValue = inputValue.PadLeft(length, '0');
            return outputValue;
        }

        /// <summary>
        ///     Parse City, State and zip into individual components
        /// </summary>
        /// <param name="rowCsz"></param>
        /// <returns></returns>
        public CityStateZipAddress ParseCityStateZip(string rowCsz)
        {
            var address = new CityStateZipAddress();
            if (!rowCsz.Contains(","))
            {
                address.City       = rowCsz;
                address.State      = string.Empty;
                address.PostalCode = string.Empty;
            }
            else
            {
                address.City =
                    rowCsz.Substring(0, rowCsz.IndexOf(",", StringComparison.Ordinal));
                address.State =
                    rowCsz.Substring(rowCsz.IndexOf(",", StringComparison.Ordinal) + 2,
                                     2);
                address.PostalCode =
                    rowCsz.Substring(rowCsz.IndexOf(",", StringComparison.Ordinal) + 5);
            }
            return address;
        }

        public DateTime ReturnLastDayOfPriorMonth { get; set; }
    }

    public class CityStateZipAddress
    {
        public string City       { get; set; }
        public string State      { get; set; }
        public string PostalCode { get; set; }
    }
}