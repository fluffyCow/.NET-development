using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnvironmentCrime_4.Models;

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
            ViewBag.ErrandId = id;
            return View("CrimeView", repository);
        }
    }
}