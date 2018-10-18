
using Microsoft.AspNetCore.Mvc;
using EnvironmentCrime_4.Models;
using EnvironmentCrime_4.Infrastructure;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Threading.Tasks;

namespace EnvironmentCrime_4.Controllers
{
    /// <summary>
    /// Controller for the investigators
    /// </summary>
    public class InvestigatorController : Controller
    {

        private IRepository repository;
        private IHostingEnvironment environment;

        public InvestigatorController(IRepository repo, IHostingEnvironment env)
        {
            repository = repo;
            environment = env;
        }
        public IActionResult Start()
        {
            return View("StartInvestigatorView", repository);
        }

        /// <summary>
        /// Displays details about a specific errand
        /// </summary>
        /// <param name="id">ErrandId</param>
        /// <returns>a view with the Errand details</returns>
        public IActionResult Crime(int id)
        {
            //List of statuses used in the drop down list
            ViewBag.StatusList = repository.ErrandStatuses;

            //Save the errand ID in the session so we know which errand to update
            HttpContext.Session.SetJson("CurrentErrandId", id);

            //Send the errand id in the viewbag (used in component)
            ViewBag.ErrandId = id;
            return View("CrimeView");
        }

        /// <summary>
        /// Update an existing errand with a new department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SaveErrand(Errand e)
        {
            //Fetch the errandID from session
            int errandId = HttpContext.Session.GetJson<int>("CurrentErrandId");

            Errand errand = repository.getErrand(errandId);

            if (e.StatusId != "NULL")
            {
                //Update the errand with a new status
                errand.StatusId = e.StatusId;
            }

            if (e.InvestigatorAction != null)
            {
                //                    errand.InvestigatorAction += "\n----------------------\n";
                errand.InvestigatorAction += e.InvestigatorAction;
            }

            if (e.InvestigatorInfo != null)
            {
                //                  errand.InvestigatorInfo += "\n----------------------\n";
                errand.InvestigatorInfo += e.InvestigatorInfo;
            }

            /**            if (e.ImageFile != null)
                        {
                            Picture p = new Picture { ErrandId = errandId };
                            UploadFile(e.ImageFile, p);
                        }

                        if (e.SampleFile != null)
                        {
                            Sample s = new Sample { ErrandId = errandId };
                            UploadFile(e.SampleFile, s);
                        }
                        **/

            //Save the changes to the database. Ignore output
            repository.SaveErrand(errand);


            //Remove the errand from the session
            HttpContext.Session.Remove("CurrentErrandId");

            //Go back to the start view
            return View("StartInvestigatorView", repository);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFiles(IFormFile SampleFile, IFormFile ImageFile, String InvestigatorAction, String StatusId, String InvestigatorInfo)
        {
            //Fetch the errandID from session
            int errandId = HttpContext.Session.GetJson<int>("CurrentErrandId");

            Errand errand = repository.getErrand(errandId);

            if (!String.IsNullOrEmpty(StatusId))
            {
                //Update the errand with a new status
                errand.StatusId = StatusId;
            }

            if (!String.IsNullOrEmpty(InvestigatorAction))
            {
                //                    errand.InvestigatorAction += "\n----------------------\n";
                errand.InvestigatorAction += InvestigatorAction;
            }

            if (!String.IsNullOrEmpty(InvestigatorInfo))
            {
                //                  errand.InvestigatorInfo += "\n----------------------\n";
                errand.InvestigatorInfo += InvestigatorInfo;
            }

            if (SampleFile != null)
            {
                //den temporära sökvägen 
                var tempPath = Path.GetTempFileName();
                if (SampleFile.Length > 0)
                {
                    using (var stream = new FileStream(tempPath, FileMode.Create))
                    {
                        await SampleFile.CopyToAsync(stream);
                    }
                }

                //den nya sökvägen
                var path = Path.Combine(environment.WebRootPath, "Uploads", SampleFile.FileName);

                //flytta den temporära filen rätt
                System.IO.File.Move(tempPath, path);

                Sample s = new Sample { SampleName = SampleFile.FileName, ErrandId = errandId };
                repository.SaveObjectToDB(s);
            }

            if (ImageFile != null)
            {
                //den temporära sökvägen 
                var tempPath = Path.GetTempFileName();

                if (ImageFile.Length > 0)
                {
                    using (var stream = new FileStream(tempPath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }
                }

                //den nya sökvägen
                var path = Path.Combine(environment.WebRootPath, "Uploads", ImageFile.FileName);

                //flytta den temporära filen rätt
                System.IO.File.Move(tempPath, path);

                Picture p = new Picture { PictureName = ImageFile.FileName, ErrandId = errandId };
                repository.SaveObjectToDB(p);
            }


            //Save the changes to the database. Ignore output
            repository.SaveErrand(errand);


            //Remove the errand from the session
            HttpContext.Session.Remove("CurrentErrandId");



            //Go back to the start view
            return View("StartInvestigatorView", repository);
        }
    }

}