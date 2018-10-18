using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace EnvironmentCrime_4.Models
{
    /// <summary>
    /// Helper class used when fetching data from the form on the investigator Crime page
    /// </summary>
    public class InvestigatorFormHelper
    {
        [Display(Name = "Händelser:")]
        public String InvestigatorAction { get; set; }

        [Display(Name = "Mer Information")]
        public String InvestigatorInfo { get; set; }

        [Display(Name = "Prover:")]
        public IFormFile SampleFile { get; set; }

        [Display(Name = "Ladda upp bilder:")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "Ändring av status:")]
        public String StatusId { get; set; }
    }
}
