using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnvironmentCrime_2.Models;

namespace EnvironmentCrime_2.Controllers
{
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

        public IActionResult Crime(String id)
        {
            ViewBag.ErrandId = id;
            return View("CrimeView", repository);
        }

    }
}