using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EnvironmentCrime_4.Models
{
    /// <summary>
    /// Class holding information about the departments
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Id of the department
        /// </summary>
        [Key]
        public String DepartmentId { get; set; }

        /// <summary>
        /// Name of the department
        /// </summary>
        [Required]
        public String DepartmentName { get; set; }

        public ICollection<Employee> Employee { get; set; }

        public ICollection<Errand> Errand { get; set; }
    }
}
