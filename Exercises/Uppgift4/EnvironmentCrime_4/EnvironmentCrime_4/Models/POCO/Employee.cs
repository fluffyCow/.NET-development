using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EnvironmentCrime_4.Models
{
    /// <summary>
    /// Class hoding information about an employee
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// The If of the employee
        /// </summary>
        [Key]
        public String EmployeeId { get; set; }

        /// <summary>
        /// The name of the employee
        /// </summary>
        [Required]
        public String EmployeeName { get; set; }

        /// <summary>
        /// The title of the employee
        /// </summary>
        public String RoleTitle { get; set; }

        /// <summary>
        /// The department where the employee works
        /// </summary>

        [ForeignKey("DepartmentId")]
        public String DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Errand> Errand { get; set; }
    }
}
