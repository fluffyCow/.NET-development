using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EnvironmentCrime_3.Models
{
    /// <summary>
    /// Class holding information about the departments
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Id of the department
        /// </summary>
        public String DepartmentId { get; set; }

        /// <summary>
        /// Name of the department
        /// </summary>
        public String DepartmentName { get; set; }
    }
}
