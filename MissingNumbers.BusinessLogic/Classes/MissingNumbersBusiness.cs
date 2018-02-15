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
                missingNumbersViewModel.ErrorMessage = "Ocurrió un error convirtiendo los números.";
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
                return "La diferencia entre los numeros del segundo arreglo es mayor a 100";
            }

            if (missingNumbersViewModel.FirstArrayLength < 1)
            {
                return "La longitud del primer arreglo debe ser mayor a 1";
            }

            if (missingNumbersViewModel.SecondArrayLength > 2 * Math.Pow(10, 5))
            {
                return "Longitud del segundo arreglo demasiado grande";
            }

            if (missingNumbersViewModel.FirstArrayLength > missingNumbersViewModel.SecondArrayLength)
            {
                return "El segundo arreglo debe ser mayor que el primero";
            }

            if (missingNumbersViewModel.SecondArrayNumbers.Max() > Math.Pow(10, 4) || missingNumbersViewModel.SecondArrayNumbers.Min() < 1)
            {
                return "Los números del segundo arreglo están fuera del rango";
            }

            return string.Empty;
        }
    }
}