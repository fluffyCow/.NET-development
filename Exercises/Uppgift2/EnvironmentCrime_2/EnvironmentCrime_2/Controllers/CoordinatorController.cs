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
            return View("StartView", repository);
        }

        public IActionResult Crime(String id)
        {
            var errand = repository.Errands.Where (e => e.ErrandID == id).First();

            return View("CrimeView", errand);
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