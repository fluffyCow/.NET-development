using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EnvironmentCrime_1.Controllers
{
    public class CoordinatorController : Controller
    {
        public IActionResult Start()
        {
            return View("StartView");
        }

        public IActionResult Crime()
        {
            return View("CrimeView");
        }

        public IActionResult ReportCrime()
        {
            return View("ReportCrimeView");
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