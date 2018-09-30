using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnvironmentCrime_2.Models;

namespace EnvironmentCrime_2.Controllers
{
    /// <summary>
    /// Controller for the Coordinators
    /// </summary>
    public class CoordinatorController : Controller
    {
        //Repository holding errands, staff, statuses etc.
        private IRepository repository;

        public CoordinatorController (IRepository repo)
        {
            repository = repo;
        }

        public IActionResult Start()
        {
            return View("StartCoordinatorView", repository);
        }

        /// <summary>
        /// Display details about a specific crime/errand
        /// </summary>
        /// <param name="id">ErrandId</param>
        /// <returns></returns>
        public IActionResult Crime(String id)
        {
            ViewBag.ErrandId = id;
            return View("CrimeView", repository);
        }

        public IActionResult ReportCrime()
        {
            return View("ReportCrimeView");
        }

        public IActionResult Thanks()
        {
            return View("ThanksView");
        }

        /// <summary>
        /// Used for validation the create new errand form. Data is validated and the user is sent to
        /// the validation page if all ok, otherwise remain on the same page an display errors
        /// </summary>
        /// <param name="errand">Errand object send from the form</param>
        /// <returns>The repostCrime view if validation fails, or a redirect to the validate view</returns>
        [HttpPost]
        public IActionResult Validate(Errand errand)
        {
            if (ModelState.IsValid)
            {
                return View("ValidateView", errand);
            }
            else
            {
                return View("ReportCrimeView");
            }
        }
    }
}