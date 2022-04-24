// Created By:           Lee Marrette
//           Date:           //
//     Solution:           JobVite
//       Project:           CommonLibrary
namespace CommonLibrary
{
    public interface IStateFormatter
    {
        /// <summary>
        /// Returns abbreviation for state 
        /// </summary>
        /// <param name="inState">Name of state</param>
        /// <returns>Abbreviated name</returns>
        string ReturnStateAbbreviation(string inState);
    }
}