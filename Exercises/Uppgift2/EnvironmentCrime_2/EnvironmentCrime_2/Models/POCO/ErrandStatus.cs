using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnvironmentCrime_2.Models
{
    /// <summary>
    /// Class holding information about available statuses for errands
    /// </summary>
    public class ErrandStatus
    {
        /// <summary>
        /// The id of the status
        /// </summary>
        public String StatusId { get; set; }

        /// <summary>
        /// The name of the status
        /// </summary>
        public String StatusName { get; set; }
    }
}
