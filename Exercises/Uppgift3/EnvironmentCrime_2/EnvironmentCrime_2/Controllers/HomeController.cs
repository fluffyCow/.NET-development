using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnvironmentCrime_3.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnvironmentCrime_3.Controllers
{
    /// <summary>
    /// Controller for Home
    /// </summary>
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View("Index");

        }

        /// <summary>
        /// Overloaded but with a Errand as argument. Called from the report crime form.
        /// Used for validation the create new errand form. Data is validated and the user is sent to
        /// the validation page if all ok, otherwise remain on the same page an display errors
        /// </summary>
        /// <param name="errand">Errand object send from the form</param>
        /// <returns>The index view if validation fails, or a redirect to the validate view in the citizen controller</returns>
        [HttpPost]
        public IActionResult Index(Errand errand)
        {
            if (ModelState.IsValid)
            {
                //Sort of ok sollution to return the view instead of going through the controller here
                return View("..//Citizen/ValidateView", errand);
            }
            else
            {
                return View("Index");
            }
        }
        

        public IActionResult Login()
        {
            return View("LoginView");
        }
    }
}
