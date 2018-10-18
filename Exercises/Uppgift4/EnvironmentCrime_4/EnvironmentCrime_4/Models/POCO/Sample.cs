using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnvironmentCrime_4.Models
{
    public class Sample
    {
        [Key]
        public int SampleId { get; set; }
        public String SampleName { get; set; }

        [ForeignKey("ErrandId")]
        public Errand Errand { get; set; }
        public int ErrandId { get; set; }

    }
}
