using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EnvironmentCrime_1.Controllers
{
    public class InvestigatorController : Controller
    {
        public IActionResult Start()
        {
            return View("StartView");
        }

        public IActionResult Crime()
        {
            return View("CrimeView");
        }
    }
}