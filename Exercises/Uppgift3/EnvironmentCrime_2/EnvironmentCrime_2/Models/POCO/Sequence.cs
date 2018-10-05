using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EnvironmentCrime_3.Models
{
    public class Sequence
    {
        [Key]
        public int Id { get; set; }
        public int CurrentValue { get; set; }
    }
}
