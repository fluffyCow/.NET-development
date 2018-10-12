using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EnvironmentCrime_4.Models;
using EnvironmentCrime_4.Infrastructure;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnvironmentCrime_4.Controllers
{
    /// <summary>
    /// Controller for Home
    /// </summary>
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var errand = HttpContext.Session.GetJson<Errand>("NewErrand");

            if(errand == null)
            {
                return View("Index");
            }
            else
            {
                return View("Index", errand);
            }
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
            HttpContext.Session.SetJson("NewErrand", errand); 
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
