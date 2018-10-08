using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EnvironmentCrime_3.Models
{
    /// <summary>
    /// Class hoding information about an employee
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// The If of the employee
        /// </summary>
        public String EmployeeId { get; set; }

        /// <summary>
        /// The name of the employee
        /// </summary>
        public String EmployeeName { get; set; }

        /// <summary>
        /// The title of the employee
        /// </summary>
        public String RoleTitle { get; set; }

        /// <summary>
        /// The department where the employee works
        /// </summary>
        public String DepartmentId { get; set; }

    }
}
