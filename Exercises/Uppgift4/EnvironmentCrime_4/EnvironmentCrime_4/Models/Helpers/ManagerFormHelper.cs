using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EnvironmentCrime_4.Models
{
    /// <summary>
    /// Helper class used when fetching data from the form on the manager Crime page
    /// </summary>
    public class ManagerFormHelper
    {
        [Display(Name = "Ange handläggare:")]
        public String EmployeeId { get; set; }

        [Display(Name = "Ingen åtgärd:")]
        public bool  NoAction { get; set; }

        [Display(Name = "Ange motivering")]
        public String Reason { get; set; }
    }
}
