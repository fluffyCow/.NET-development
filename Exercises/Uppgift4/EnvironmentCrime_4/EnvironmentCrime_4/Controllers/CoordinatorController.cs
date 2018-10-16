using System.Linq;
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
            //List of departments used in the drop down list, Except D00 - should not be used
            ViewBag.DepartmentList = repository.Departments.Where(d => d.DepartmentId != "D00");

            //Save the errand ID in the session so we know which errand to update
            HttpContext.Session.SetJson("ErrandId", id);

            //Send the errand id in the viewbag (used in component)
            ViewBag.ErrandId = id;
            return View("CrimeView");//, repository);
        }

        /// <summary>
        /// Display the report crime page
        /// </summary>
        /// <returns></returns>
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
                //Sort of ok solution to return the view instead of going through the controller here
                return View("ValidateView", errand);
            }
            else
            {
                return View("ReportCrimeView");
            }
        }

        /// <summary>
        /// Save the new errand to the database and display thank you
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Update an existing errand with a new department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SaveErrand(Department department)
        {
            //Only save if we have data
            if (department.DepartmentId != "NULL")
            {
                //Fetch the errandID from session
                int errandId = HttpContext.Session.GetJson<int>("ErrandId");

                Errand errand = repository.getErrand(errandId);

                //Update the errand with a new department
                errand.DepartmentId = department.DepartmentId;

                //Save the changes to the database. Ignore output
                repository.SaveErrand(errand);
            }
            //Remove the errand from the session
            HttpContext.Session.Remove("ErrandId");

            //Go back to the start view
            return View("StartCoordinatorView", repository);
        }
    }
}