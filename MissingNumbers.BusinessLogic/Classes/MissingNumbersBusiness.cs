// -------------------------------------------------------------------------------
// <copyright file="MissingNumbersBusiness.cs" company="MissingNumbers">
// MissingNumbers
// </copyright>
// <author>Herley Puerta</author>
// <email>hypuerta@hotmail.com</email>
// <date>14/02/2018</date>
// <summary>Implements Missing Numbers Business.</summary>
// -------------------------------------------------------------------------------
namespace MissingNumbers.BusinessLogic.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BusinessLogic.Interfaces;
    using Entities;
    using Utilities.Resources;

    /// <summary>
    /// Implements Missing Numbers Business.
    /// </summary>
    public class MissingNumbersBusiness : IMissingNumbersBusiness
    {
        /// <summary>
        /// Get Missing Numbers.
        /// </summary>
        /// <param name="missingNumbersViewModel">Instance of MissingNumbersViewModel.</param>
        /// <returns>Missing Numbers.</returns>
        public string GetMissingNumbers(MissingNumbersViewModel missingNumbersViewModel)
        {
            missingNumbersViewModel = this.GetArrays(missingNumbersViewModel);
            if (string.IsNullOrEmpty(missingNumbersViewModel.ErrorMessage))
            {
                Dictionary<int, int> firstArrayFrecuency = this.GetFrecuency(missingNumbersViewModel.FirstArrayNumbers);
                Dictionary<int, int> secondArrayFrecuency = this.GetFrecuency(missingNumbersViewModel.SecondArrayNumbers);
                return this.VerifyFrecuency(firstArrayFrecuency, secondArrayFrecuency);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Get quantity of every number in an array.
        /// </summary>
        /// <param name="arrayNumber">Array to validate.</param>
        /// <returns>Quantity of every number in an array.</returns>
        private Dictionary<int, int> GetFrecuency(List<int> arrayNumber)
        {
            Dictionary<int, int> numberFrecuency = new Dictionary<int, int>();
            foreach (int number in arrayNumber)
            {
                if (numberFrecuency.ContainsKey(number))
                {
                    numberFrecuency[number] += 1;
                }
                else
                {
                    numberFrecuency.Add(number, 1);
                }
            }

            return numberFrecuency;
        }

        /// <summary>
        /// Get arrays of numbers from string of numbers.
        /// </summary>
        /// <param name="missingNumbersViewModel">Instance of MissingNumbersViewModel.</param>
        /// <returns>Arrays of numbers from string of numbers.</returns>
        private MissingNumbersViewModel GetArrays(MissingNumbersViewModel missingNumbersViewModel)
        {
            try
            {
                string[] tempNumbersFirstArray = missingNumbersViewModel.FirstArrayStringNumbers.Split(' ');
                string[] tempNumbersSecondArray = missingNumbersViewModel.SecondArrayStringNumbers.Split(' ');
                missingNumbersViewModel.FirstArrayNumbers = Array.ConvertAll(tempNumbersFirstArray, int.Parse).ToList();
                missingNumbersViewModel.SecondArrayNumbers = Array.ConvertAll(tempNumbersSecondArray, int.Parse).ToList();
                missingNumbersViewModel.ErrorMessage = this.ValidateArrays(missingNumbersViewModel);
            }
            catch (Exception)
            {
                missingNumbersViewModel.ErrorMessage = MissingNumbersMessages.ErrorConvertingNumbers;
            }

            return missingNumbersViewModel;
        }

        /// <summary>
        /// Compare two dictionaries of numbers and get differences.
        /// </summary>
        /// <param name="firstArrayfrecuency">First dictionary to compare.</param>
        /// <param name="secondArrayFrecuency">Second dictionary to compare.</param>
        /// <returns>Differences between two dictionaries.</returns>
        private string VerifyFrecuency(Dictionary<int, int> firstArrayfrecuency, Dictionary<int, int> secondArrayFrecuency)
        {
            List<int> missingNumbers = new List<int>();
            foreach (int key in secondArrayFrecuency.Keys)
            {
                if (firstArrayfrecuency.ContainsKey(key))
                {
                    if (secondArrayFrecuency[key] > firstArrayfrecuency[key])
                    {
                        missingNumbers.Add(key);
                    }
                }
                else
                {
                    missingNumbers.Add(key);
                }
            }

            missingNumbers.Sort();
            return string.Join(" ", missingNumbers);
        }

        /// <summary>
        /// Validate arrays of numbers.
        /// </summary>
        /// <param name="missingNumbersViewModel">Instance of MissingNumbersViewModel.</param>
        /// <returns>Error message.</returns>
        private string ValidateArrays(MissingNumbersViewModel missingNumbersViewModel)
        {
            if ((missingNumbersViewModel.SecondArrayNumbers.Max() - missingNumbersViewModel.SecondArrayNumbers.Min()) > 100)
            {
                return MissingNumbersMessages.ErrorSecondArrayDifferenceNunmberGreater100;
            }

            if (missingNumbersViewModel.FirstArrayLength < 1)
            {
                return MissingNumbersMessages.ErrorLengthFirstArray;
            }

            if (missingNumbersViewModel.SecondArrayLength > 2 * Math.Pow(10, 5))
            {
                return MissingNumbersMessages.ErrorSecondArrayGreat;
            }

            if (missingNumbersViewModel.FirstArrayLength > missingNumbersViewModel.SecondArrayLength)
            {
                return MissingNumbersMessages.ErrorArraysLength;
            }

            if (missingNumbersViewModel.SecondArrayNumbers.Max() > Math.Pow(10, 4) || missingNumbersViewModel.SecondArrayNumbers.Min() < 1)
            {
                return MissingNumbersMessages.ErrorSecondArrayNumbersOutOfRange;
            }

            return string.Empty;
        }
    }
}