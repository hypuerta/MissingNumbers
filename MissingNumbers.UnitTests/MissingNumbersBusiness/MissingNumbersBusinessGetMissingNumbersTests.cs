// -------------------------------------------------------------------------------
// <copyright file="MissingNumbersBusinessGetMissingNumbersTests.cs" company="MissingNumbers">
// MissingNumbers
// </copyright>
// <author>Herley Puerta</author>
// <email>hypuerta@hotmail.com</email>
// <date>14/02/2018</date>
// <summary>Test Class MissingNumbersBusinessGetMissingNumbersTests.</summary>
// -------------------------------------------------------------------------------
namespace MissingNumbers.UnitTests.MissingNumbersBusiness
{
    using BusinessLogic.Classes;
    using BusinessLogic.Interfaces;
    using Entities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test Class MissingNumbersBusinessGetMissingNumbersTests.
    /// </summary>
    [TestClass]
    public class MissingNumbersBusinessGetMissingNumbersTests
    {
        /// <summary>
        /// Business Missing numbers.
        /// </summary>
        private IMissingNumbersBusiness missingNumbersBusiness = null;

        /// <summary>
        /// Initialize values to test.
        /// </summary>
        [TestInitialize]
        public void InitializeTest()
        {
            this.missingNumbersBusiness = new MissingNumbersBusiness();
        }

        /// <summary>
        /// Test get missing numbers with string.
        /// </summary>
        [TestMethod]
        public void GetMissingNumbersArrayWithoutNumbers()
        {
            MissingNumbersViewModel missingNumbersViewModel = new MissingNumbersViewModel()
            {
                FirstArrayLength = 1,
                SecondArrayLength = 1,
                FirstArrayStringNumbers = "a",
                SecondArrayStringNumbers = "b"
            };

            string result = this.missingNumbersBusiness.GetMissingNumbers(missingNumbersViewModel);
            Assert.AreEqual("Ocurrió un error convirtiendo los números.", missingNumbersViewModel.ErrorMessage);
            Assert.AreEqual(string.Empty, result);
        }

        /// <summary>
        /// Test get missing empty text.
        /// </summary>
        [TestMethod]
        public void GetMissingNumbersArrayEmptyText()
        {
            MissingNumbersViewModel missingNumbersViewModel = new MissingNumbersViewModel()
            {
                FirstArrayLength = 1,
                SecondArrayLength = 1,
                FirstArrayStringNumbers = " ",
                SecondArrayStringNumbers = " "
            };

            string result = this.missingNumbersBusiness.GetMissingNumbers(missingNumbersViewModel);
            Assert.AreEqual("Ocurrió un error convirtiendo los números.", missingNumbersViewModel.ErrorMessage);
            Assert.AreEqual(string.Empty, result);
        }

        /// <summary>
        /// Test gest missing numbers success.
        /// </summary>
        [TestMethod]
        public void GetMissingNumbersSuccess()
        {
            MissingNumbersViewModel missingNumbersViewModel = new MissingNumbersViewModel()
            {
                FirstArrayLength = 1,
                SecondArrayLength = 1,
                FirstArrayStringNumbers = "1",
                SecondArrayStringNumbers = "2"
            };

            string result = this.missingNumbersBusiness.GetMissingNumbers(missingNumbersViewModel);
            Assert.AreEqual(string.Empty, missingNumbersViewModel.ErrorMessage);
            Assert.AreNotEqual(string.Empty, result);
        }
    }
}
