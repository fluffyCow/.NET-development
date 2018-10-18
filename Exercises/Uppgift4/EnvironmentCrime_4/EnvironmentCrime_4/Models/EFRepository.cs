using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EnvironmentCrime_4.Models
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
        /// Gives you the next available errandId
        /// </summary>
        /// <returns></returns>
        private String GetCurrentErrandRefNumber()
        {
            //get the Current IDvalue, stored with ID=1, There are some trash data in this table that should be ignored.
            var seq = Sequences.Where(s => s.Id == 1).First();

            if (seq != null)
            {
                //return the current reference number based on the
                //pattern YY-45-ID. Ex 2018-45-200
                return DateTime.Now.Year +"-"+ "45" +"-"+ seq.CurrentValue; ;
            } else
            {
                return null;
            }
        }

        /// <summary>
        /// Increase the sequence number. If there is none, set it to default value 200
        /// </summary>
        private void IncreaseErrandRefNumber()
        {
            //Get the current row
            var s = Sequences.Where(seq => seq.Id == 1).First();

            if (s != null)
            {
                //Increment the value
                s.CurrentValue = s.CurrentValue+1;
            } else
            {
                //If the database is empty add an id with default value 200
                s = new Sequence();
                context.Sequences.Add(s);
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Saves an errand to the database
        /// </summary>
        /// <param name="e">The errand object</param>
        /// <returns>the ErrandId of the newly created errand</returns>
        public String SaveErrand(Errand errand)
        {
            if (errand.ErrandID == 0)
            {
                //Give the errand a new refnumber
                errand.RefNumber = GetCurrentErrandRefNumber();
                IncreaseErrandRefNumber();

                //Set statusid of the errand to S_A
                errand.StatusId = "S_A";

                //Add it to the db
                context.Errands.Add(errand);
            } else
            {
                Errand dbEntry = context.Errands.FirstOrDefault(e => e.ErrandID == errand.ErrandID);
                if(dbEntry != null)
                {
                    dbEntry = errand;
                }

            }
            context.SaveChanges();

            //Return the reference number of the new errand
            return errand.RefNumber;
        }

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


                errand.Pictures = Pictures.Where(p => p.ErrandId == id).ToList();
                errand.Samples = Samples.Where(s => s.ErrandId == id).ToList();

                return errand;
            });
        }

        public Errand getErrand(int id)
        {
            var errand = Errands.Where(e => e.ErrandID == id).First();
                        
            return errand;
        }

        /// <summary>
        /// Save an object to the db
        /// </summary>
        /// <param name="o"></param>
        public String SaveObjectToDB(Object o)
        {
            if (o is Errand)
            {
                return SaveErrand(o as Errand);
            }
            else { 
                context.Add(o);

                context.SaveChanges();

                return "";
            }
        }


    }
}
