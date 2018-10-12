using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnvironmentCrime_4.Models;
using EnvironmentCrime_4.Infrastructure;

namespace EnvironmentCrime_4.Controllers
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
        public IActionResult Crime(int id)
        {
            ViewBag.ErrandId = id;
            return View("CrimeView", repository);
        }

        public IActionResult ReportCrime()
        {
            
            var errand = HttpContext.Session.GetJson<Errand>("NewErrand");

            if (errand == null)
            {
                return View("ReportCrimeView");
            }
            else
            {
                return View("ReportCrimeView", errand);
            }
        }

        [HttpPost]
        public IActionResult ReportCrime(Errand errand)
        {
            HttpContext.Session.SetJson("NewErrand", errand);

            if (ModelState.IsValid)
            {
                //Sort of ok sollution to return the view instead of going through the controller here
                return View("ValidateView", errand);
            }
            else
            {
                return View("ReportCrimeView");
            }
        }

        public IActionResult Thanks()
        {
            var e = HttpContext.Session.GetJson<Errand>("NewErrand");

            //Save the errand to the database
            ViewBag.RefNumber = repository.SaveErrand(e);

            //Remove the errand after is has been saved to the db
            HttpContext.Session.Remove("NewErrand");
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
            return View("ValidateView", errand);
        }
    }
}