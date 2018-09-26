using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnvironmentCrime_2.Models
{
    public class Errand
    {
        public String ErrandID{ get; set; }

        public String Place { get; set; }

        public String TypeOfCrime { get; set; }

        public DateTime DateOfObservation { get; set; }

        public String Observation { get; set; }

        public String InvestigatorAction { get; set; }

        public String InvestigatorInfo { get; set; }

        public String InformerName { get; set; }

        public String InformerPhone { get; set; }

        public String StatusId { get; set; }

        public String DepartmentId { get; set; }

        public String EmployeeId { get; set; }
    }
}
