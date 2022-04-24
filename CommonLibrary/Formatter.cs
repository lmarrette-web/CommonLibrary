// Created By:           Lee Marrette
//           Date:           03/25/2019
//     Solution:           JobVite
//       Project:           CommonLibrary

namespace CommonLibrary
{
    public class Formatter
    {
        /// <summary>
        /// Unconditionally wrap input string with double quotes
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Quoted String</returns>
        public string AddQuotesToString(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
           // if (input.Contains(","))
            return "\"" + input + "\"";
        }

        /// <summary>
        /// Some intgrations require the tsged address for SSO
        /// Replace Workday address with @tsged.com
        /// </summary>
        /// <param name="address"></param>
        /// <returns>Updated address</returnsed>
        public string ReturnEmailAddressUsingTsged(string address)
        {
            if (string.IsNullOrEmpty(address)) return string.Empty;
            string[] addressParts = address.Split('@');
            return addressParts[0] + "@tsged.com";
        }
    }
}