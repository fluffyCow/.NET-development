using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnvironmentCrime_3.Models
{
    public class EFRepository : IRepository
    {
        private ApplicationDbContext context;

        public EFRepository (ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Errand> Errands => context.Errands;
        public IQueryable<ErrandStatus> ErrandStatuses=> context.ErrandStatuses;
        public IQueryable<Department> Departments => context.Departments;
        public IQueryable<Employee> Employees => context.Employees;
        public IQueryable<Sample> Samples => context.Samples;
        public IQueryable<Picture> Pictures => context.Pictures;
        public IQueryable<Sequence> Sequences => context.Sequences;


        /// <summary>
        /// Task that returns one errand with id 
        /// </summary>
        /// <param name="id">ErrandID</param>
        /// <returns>Details about one errand</returns>
        public Task<Errand> GetErrandDetail(int id)
        {
            return Task.Run(() =>
            {
                var errand = Errands.Where(e => e.ErrandID == id).First();
                return errand;
            });
        }
    }
}
