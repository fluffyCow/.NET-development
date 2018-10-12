using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EnvironmentCrime_4.Models
{
    /// <summary>
    /// Bridge between EF and EnvironemntCrime
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Create a context for our database connection
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext
            (DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        //The objects/tables being used in the database
        public DbSet<Errand> Errands { get; set; }
        public DbSet<ErrandStatus> ErrandStatuses { get; set; }
        public DbSet<Employee>  Employees{ get; set; }
        public DbSet<Department> Departments{ get; set; }
        public DbSet<Sample> Samples { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Sequence> Sequences { get; set; }
    }
}
