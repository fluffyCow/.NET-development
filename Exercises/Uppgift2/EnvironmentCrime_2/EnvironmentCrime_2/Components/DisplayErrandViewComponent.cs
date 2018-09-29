using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnvironmentCrime_2.Models;

namespace EnvironmentCrime_2.Components
{
    public class DisplayErrandViewComponent : ViewComponent
    {
        private IRepository repository;

        public DisplayErrandViewComponent(IRepository repo)
        {
            repository = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync(String id)
        {
            var errand = await repository.GetErrandDetail(id);    
            return View("DisplayErrand", errand);
        }


    }
}
