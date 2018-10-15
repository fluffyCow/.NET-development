
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EnvironmentCrime_4.Models
{
    public interface IRepository
    {
        IQueryable<Errand> Errands { get; }

        IQueryable<Department> Departments { get; }

        IQueryable<ErrandStatus> ErrandStatuses { get; }

        IQueryable<Employee> Employees { get; }

        IQueryable<Picture> Pictures { get; }

        IQueryable<Sample> Samples { get; }

        IQueryable<Sequence> Sequences {get;}

        Task<Errand> GetErrandDetail(int id);

        //Saves/updates an errand. Returns and the reference ID
        String SaveErrand(Errand errand);

        /// <summary>
        /// Fetches a single errand from the db
        /// </summary>
        /// <param name="Id">ErrandId (int)</param>
        /// <returns>errand object with the ID</returns>
        Errand getErrand(int Id);
    }
 }
