using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EnvironmentCrime_4.Models
{
    public class Sequence
    {
        /// <summary>
        /// If there are no Errandsequence set up. create one with id 200
        /// </summary>
        public Sequence()
        {
            CurrentValue = 200;
        }

        [Key]
        public int Id { get; set; }
        public int CurrentValue { get; set; }
    }
}
