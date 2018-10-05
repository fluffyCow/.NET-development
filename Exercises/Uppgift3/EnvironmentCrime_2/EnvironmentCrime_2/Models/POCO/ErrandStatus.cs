using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EnvironmentCrime_3.Models
{
    /// <summary>
    /// Class holding information about available statuses for errands
    /// </summary>
    public class ErrandStatus
    {
        /// <summary>
        /// The id of the status
        /// </summary>
        [Key]
        public String StatusId { get; set; }

        /// <summary>
        /// The name of the status
        /// </summary>
        public String StatusName { get; set; }
    }
}
