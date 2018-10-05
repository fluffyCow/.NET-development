using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EnvironmentCrime_3.Models
{
    public class Sample
    {
        [Key]
        public int SampleId { get; set; }
        public String SampleName { get; set; }


        public int ErrandId { get; set; }
    }
}
