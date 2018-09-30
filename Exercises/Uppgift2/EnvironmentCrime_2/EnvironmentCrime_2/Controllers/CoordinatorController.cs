using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnvironmentCrime_2.Models;

namespace EnvironmentCrime_2.Controllers
{
    public class CoordinatorController : Controller
    {
        private IRepository repository;

        public CoordinatorController (IRepository repo)
        {
            repository = repo;
        }

        public IActionResult Start()
        {
            return View("StartCoordinatorView", repository);
        }

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

        [HttpPost]
        public IActionResult Validate(ReportCrime reportCrime)
        {
            if (ModelState.IsValid)
            {
                return View("ValidateView", reportCrime);
            }
            else
            {
                return View("ReportCrimeView");
            }
        }
    }
}