using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnvironmentCrime_3.Models;

namespace EnvironmentCrime_3.Controllers
{
    /// <summary>
    /// Controller for the Citizen sub pages
    /// </summary>
    public class CitizenController : Controller
    {
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