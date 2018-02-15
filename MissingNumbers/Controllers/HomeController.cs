// -------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="MissingNumbers">
// MissingNumbers
// </copyright>
// <author>Herley Puerta</author>
// <email>hypuerta@hotmail.com</email>
// <date>14/02/2018</date>
// <summary>Implements Home Controller.</summary>
// -------------------------------------------------------------------------------
namespace MissingNumbers.Controllers
{
    using System.Web.Mvc;
    using BusinessLogic.Classes;
    using Entities;

    /// <summary>
    /// Implements Home Controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Action Index.
        /// </summary>
        /// <returns>View Index.</returns>
        public ActionResult Index()
        {
            return this.View(new MissingNumbersViewModel());
        }

        /// <summary>
        /// Post data to get missing numbers.
        /// </summary>
        /// <param name="missingNumbersViewModel">Instance of MissingNumbersViewModel.</param>
        /// <returns>View Index.</returns>
        [HttpPost]
        public ActionResult Index(MissingNumbersViewModel missingNumbersViewModel)
        {
            missingNumbersViewModel.MissingNumbersResult = new MissingNumbersBusiness().GetMissingNumbers(missingNumbersViewModel);
            return this.View(missingNumbersViewModel);
        }
    }
}