﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnvironmentCrime_3.Models;

namespace EnvironmentCrime_3.Controllers
{
    /// <summary>
    /// Controller for the managers
    /// </summary>
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

        /// <summary>
        /// Displays details about a specific errand
        /// </summary>
        /// <param name="id">ErrandId</param>
        /// <returns>a view with the Errand details</returns>
        public IActionResult Crime(int id)
        {
            ViewBag.ErrandId = id;
            return View("CrimeView", repository);
        }

    }
}