using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EnvironmentCrime_2.Controllers
{
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
            return View("ThanksView");
        }

        public IActionResult Validate()
        {
            return View("ValidateView");
        }
    }
}