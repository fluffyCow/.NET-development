﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnvironmentCrime_3.Models;

namespace EnvironmentCrime_3.Components
{
    /// <summary>
    /// ViewComponent for displaying details about a specific errand
    /// </summary>
    public class DisplayErrandViewComponent : ViewComponent
    {
        //Repository of all errands, staff etc.
        private IRepository repository;

        public DisplayErrandViewComponent(IRepository repo)
        {
            repository = repo;
        }

        /// <summary>
        /// Displays information about aspecific errand
        /// </summary>
        /// <param name="id">errandId for the errand that should be listed</param>
        /// <returns>The view DisplayErrand together with an errand object containing information about the specific errand</returns>
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            //Get details about the errand from the repository
            var errand = await repository.GetErrandDetail(id);    
            return View("DisplayErrand", errand);
        }


    }
}
