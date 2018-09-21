using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EnvironmentCrime_2.Controllers
{
    public class ManagerController : Controller
    {

        public IActionResult Crime()
        {
            return View("CrimeView");
        }

        public IActionResult Start()
        {
            return View("StartView");
        }
    }
}