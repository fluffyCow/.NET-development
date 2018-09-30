using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnvironmentCrime_2.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnvironmentCrime_2.Controllers
{
    /// <summary>
    /// Controller for Home
    /// </summary>
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

        /// <summary>
        /// Used for validation the create new errand form. Data is validated and the user is sent to
        /// the validation page if all ok, otherwise remain on the same page an display errors
        /// </summary>
        /// <param name="errand">Errand object send from the form</param>
        /// <returns>The index view if validation fails, or a redirect to the validate view in the citizen controller</returns>
        [HttpPost]
        public IActionResult Validate(Errand errand)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Validate", "Citizen", errand);
            }
            else
            {
                return View("Index");
            }
        }
    }
}
