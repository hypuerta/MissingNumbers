// -------------------------------------------------------------------------------
// <copyright file="IMissingNumbersBusiness.cs" company="MissingNumbers">
// MissingNumbers
// </copyright>
// <author>Herley Puerta</author>
// <email>hypuerta@hotmail.com</email>
// <date>14/02/2018</date>
// <summary>Defines Missing Numbers Business.</summary>
// -------------------------------------------------------------------------------
namespace MissingNumbers.BusinessLogic.Interfaces
{
    using Entities;

    /// <summary>
    /// Defines Missing Numbers Business.
    /// </summary>
    public interface IMissingNumbersBusiness
    {
        /// <summary>
        /// Get Missing Numbers.
        /// </summary>
        /// <param name="missingNumbersViewModel">Instance of MissingNumbersViewModel.</param>
        /// <returns>Missing Numbers.</returns>
        string GetMissingNumbers(MissingNumbersViewModel missingNumbersViewModel);
    }
}