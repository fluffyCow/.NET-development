﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnvironmentCrime_2.Models
{

    /// <summary>
    /// Our fake repository. holding data so the application can be testeds
    /// </summary>
    public class FakeRepository : IRepository
    {
        public IQueryable<Errand> Errands => new List<Errand>
        {
            new Errand{ ErrandID = "2018-45-0001", Place = "Skogslunden vid Jensens gård", TypeOfCrime="Sopor", DateOfObservation = new DateTime(2018,04,24), Observation ="Anmälaren var på promeand i skogslunden när hon upptäckte soporna", InvestigatorInfo = "Undersökning har gjorts och bland soporna hittades bl.a ett brev till Gösta Olsson", InvestigatorAction = "Brev har skickats till Gösta Olsson om soporna och anmälan har gjorts till polisen 2018-05-01", InformerName = "Ada Bengtsson", InformerPhone = "0432-5545522", StatusId="Klar", DepartmentId="Renhållning och avfall", EmployeeId ="Susanne Fred"},

            new Errand{ ErrandID = "2018-45-0002", Place = "Småstadsjön", TypeOfCrime="Oljeutsläpp", DateOfObservation = new DateTime(2018,04,29), Observation ="Jag såg en oljefläck på vattnet när jag var där för att fiska", InvestigatorInfo = "Undersökning har gjorts på plats, ingen fläck har hittas", InvestigatorAction = "", InformerName = "Bengt Svensson", InformerPhone = "0432-5152255", StatusId="Ingen åtgärd", DepartmentId="Natur och Skogsvård", EmployeeId ="Oskar Ivarsson"},

            new Errand{ ErrandID = "2018-45-0003", Place = "Ödehuset", TypeOfCrime="Skrot", DateOfObservation = new DateTime(2018,05,02), Observation ="Anmälaren körde förbi ödehuset och upptäcker ett antal bilar och annat skrot", InvestigatorInfo = "Undersökning har gjorts och bilder har tagits", InvestigatorAction = "", InformerName = "Olle Pettersson", InformerPhone = "0432-5255522", StatusId="Påbörjad", DepartmentId="Miljö och Hälsoskydd", EmployeeId ="Lena Larsson"},

            new Errand{ ErrandID = "2018-45-0004", Place = "Restaurang Krögaren", TypeOfCrime="Buller", DateOfObservation = new DateTime(2018,06,04), Observation ="Restaurangen hade för högt ljud på så man inte kunde sova", InvestigatorInfo = "Bullermätning har gjorts. Man håller sig inom riktvärden", InvestigatorAction = "Meddelat restaurangen att tänka på ljudet i fortsättning", InformerName = "Roland Jönsson", InformerPhone = "0432-5322255", StatusId="Klar", DepartmentId="Miljö och Hälsokydd", EmployeeId ="Martin Kvist"},

            new Errand{ ErrandID = "2018-45-0005", Place = "Torget", TypeOfCrime="Klotter", DateOfObservation = new DateTime(2018,07,10), Observation ="Samtliga skräpkorgar och bänkar är nedklottrade", InvestigatorInfo = "", InvestigatorAction = "", InformerName = "Peter Svensson", InformerPhone = "0432-5322555", StatusId="Inrapporterad", DepartmentId="Ej tillsatt", EmployeeId ="Ej tillsatt"}

        }.AsQueryable();

        public IQueryable<Department> Departments => new List<Department>
        {

            new Department{DepartmentId="D00", DepartmentName="Småstads Kommun"},
            new Department{DepartmentId="D01", DepartmentName="IT-avdelningen"},
            new Department{DepartmentId="D02", DepartmentName="Lek och Skoj"},
            new Department{DepartmentId="D03", DepartmentName="Miljöskydd"}
        }.AsQueryable();

        public IQueryable<ErrandStatus> ErrandStatuses => new List<ErrandStatus>
        {
            new ErrandStatus{StatusId="S_A", StatusName="Rapporterad"},
            new ErrandStatus{StatusId="S_B", StatusName="Ingen åtgärd"},
            new ErrandStatus{StatusId="S_B", StatusName="Startad"},
            new ErrandStatus{StatusId="S_D", StatusName="Färdig"},
        }.AsQueryable();

        public IQueryable<Employee> Employees => new List<Employee>
        {
            new Employee{EmployeeId="E302", EmployeeName="Martin Kvist", RoleTitle="investigator", DepartmentId="D01"},
            new Employee{EmployeeId="E301", EmployeeName="Lena Larsson", RoleTitle="investigator", DepartmentId="D01"},
            new Employee{EmployeeId="E401", EmployeeName="Oskar Ivarsson", RoleTitle="investigator", DepartmentId="D02"},
            new Employee{EmployeeId="E501", EmployeeName="Susanne Fred", RoleTitle="investigator", DepartmentId="D03"}
        }.AsQueryable();

        public Task<Errand> GetErrandDetail(String id)
        {
            return Task.Run(() =>
            {
                var errand = Errands.Where(e => e.ErrandID == id).First();
                return errand;
            });
        }
    }

}
