
using Microsoft.AspNetCore.Mvc;
using EnvironmentCrime_4.Models;
using EnvironmentCrime_4.Infrastructure;

namespace EnvironmentCrime_4.Controllers
{
    /// <summary>
    /// Controller for the investigators
    /// </summary>
    public class InvestigatorController : Controller
    {

        private IRepository repository;

        public InvestigatorController(IRepository repo)
        {
            repository = repo;
        }
        public IActionResult Start()
        {
            return View("StartInvestigatorView", repository);
        }

        /// <summary>
        /// Displays details about a specific errand
        /// </summary>
        /// <param name="id">ErrandId</param>
        /// <returns>a view with the Errand details</returns>
        public IActionResult Crime(int id)
        {            
            //List of statuses used in the drop down list
            ViewBag.StatusList = repository.ErrandStatuses;

            //Save the errand ID in the session so we know which errand to update
            HttpContext.Session.SetJson("ErrandId", id);

            //Send the errand id in the viewbag (used in component)
            ViewBag.ErrandId = id;

            ViewBag.ErrandId = id;
            return View("CrimeView", repository);
        }

        /// <summary>
        /// Update an existing errand with a new department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SaveErrand(Errand e)
        {
            //Only save if we have data
            if (e.StatusId != "NULL")
            {
                //Fetch the errandID from session
                int errandId = HttpContext.Session.GetJson<int>("CurrentErrandId");

                Errand errand = repository.getErrand(errandId);

                //Update the errand with a new department
                errand.StatusId = e.StatusId;

                //Save the changes to the database. Ignore output
                repository.SaveErrand(errand);
            }

            //Remove the errand from the session
            HttpContext.Session.Remove("CurrentErrandId");

            //Go back to the start view
            return View("StartManagerView", repository);
        }
    }
}