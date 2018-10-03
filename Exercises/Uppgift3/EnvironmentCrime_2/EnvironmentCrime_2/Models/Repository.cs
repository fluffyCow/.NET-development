using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnvironmentCrime_3.Models
{
    public interface IRepository
    {
        IQueryable<Errand> Errands { get; } 

        IQueryable<Department> Departments { get; }

        IQueryable<ErrandStatus> ErrandStatuses { get; }

        IQueryable<Employee> Employees { get; }

        Task<Errand> GetErrandDetail(String id);
    }
 }
