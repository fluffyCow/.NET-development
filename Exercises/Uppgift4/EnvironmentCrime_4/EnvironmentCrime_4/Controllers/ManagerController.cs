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
    /// Controller for the managers
    /// </summary>
    public class ManagerController : Controller
    {
        private IRepository repository;

        public ManagerController(IRepository repo)
        {
            repository = repo;
        }

        public IActionResult Start()
        {
            return View("StartManagerView", repository);
        }

        /// <summary>
        /// Displays details about a specific errand
        /// </summary>
        /// <param name="id">ErrandId</param>
        /// <returns>a view with the Errand details</returns>
        public IActionResult Crime(int id)
        {
            //List of Employees used in the drop down list
            ViewBag.EmployeeList = repository.Employees;

            //Save the errand ID in the session so we know which errand to update
            HttpContext.Session.SetJson("CurrentErrandId", id);

            ViewBag.ErrandId = id;
            return View("CrimeView"); //, repository);
        }

        /// <summary>
        /// Update an existing errand with a new department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SaveErrand(ManagerFormHelper mfh)
        {

            //Fetch the errandID from session
            int errandId = HttpContext.Session.GetJson<int>("CurrentErrandId");

            Errand errand = repository.getErrand(errandId);

            //If the manager haven't closed the ticket, update the errand with a new employee. 
            if (!mfh.NoAction && mfh.EmployeeId != "NULL")
            {
                errand.EmployeeId = mfh.EmployeeId;
            }
            else
            {
                //Save the reason for closing the ticket and set status to no action
                errand.InvestigatorInfo = mfh.Reason;
                errand.StatusId = "S_B";
                errand.EmployeeId = null;
            }

            //Save the changes to the database. Ignore output
            repository.SaveErrand(errand);


            //Remove the errand from the session
            HttpContext.Session.Remove("CurrentErrandId");

            //Go back to the start view
            return View("StartManagerView", repository);
        }

    }
}