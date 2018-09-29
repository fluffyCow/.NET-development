using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnvironmentCrime_2.Models;

namespace EnvironmentCrime_2.Controllers
{
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

        public IActionResult Crime(String id)
        {
            ViewBag.ErrandId = id;
            return View("CrimeView", repository);
        }
    }
}