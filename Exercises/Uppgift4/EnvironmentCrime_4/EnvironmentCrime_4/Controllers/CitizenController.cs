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
    /// Controller for the Citizen sub pages
    /// </summary>
    public class CitizenController : Controller
    {
        //Repository holding errands, staff, statuses etc.
        private IRepository repository;

        public CitizenController(IRepository repo)
        {
            repository = repo;
        }

        public IActionResult Contact()
        {
            return View("ContactView");
        }

        public IActionResult Faq()
        {
            return View("FaqView");
        }

        public IActionResult Services()
        {
            return View("ServicesView");
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

        public IActionResult Validate(Errand errand)
        {
           return View("ValidateView", errand);
        }


    }
}