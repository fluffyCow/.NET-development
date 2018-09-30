﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnvironmentCrime_2.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnvironmentCrime_2.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Login()
        {
            return View("LoginView");
        }

        [HttpPost]
        public ViewResult Login(LoginModel credentials)
        {
            return View("Index");
        }

        [HttpPost]
        public IActionResult Validate(ReportCrime reportCrime)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Validate", "Citizen", reportCrime);
            }
            else
            {
                return View("Index");
            }
        }
    }
}
