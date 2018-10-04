using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace EnvironmentCrime_2.Models
{
    /// <summary>
    /// Class for storing information about an errand
    /// Also includes data annotations that can be used in forms
    /// </summary>
    public class Errand
    {
        public String ErrandID{ get; set; }

        [Display(Name = "Var har brottet skett någonstans?")]
        [Required(ErrorMessage = "Du måste fylla i var brottet skett")]
        public String Place { get; set; }

        [Display(Name = "Vilken typ av brott?")]
        [Required(ErrorMessage = "Du måste fylla i typen av brott")]
        public String TypeOfCrime { get; set; }
        
        [Display(Name = "När skedde brottet?")]
        [UIHint("Date")]
        [Required(ErrorMessage = "Du måste fylla i när brottet skedde")]
        public DateTime? DateOfObservation { get; set; }

        [UIHint("")]
        [Display(Name = "Beskriv din observation (ex. namn på misstänkt person):")]
        public String Observation { get; set; }

        public String InvestigatorAction { get; set; }

        public String InvestigatorInfo { get; set; }

        [Display(Name = "Ditt namn (för- och efternamn):")]
        [Required(ErrorMessage = "Du måste fylla i ditt namn")]
        public String InformerName { get; set; }

        //Todo make a better error when regex fails
        [Display(Name = "Din telefon:")]
        [UIHint("PhonerNumber")]
        [RegularExpression(@"^[0]{1}[0-9]{1,3}-[0-9]{5,9}$", ErrorMessage = "Fyll i ett vettigt telefonnummer istället")]
        [Required(ErrorMessage = "Du måste fylla i ditt telefonnummer")]
        public String InformerPhone { get; set; }

        public String StatusId { get; set; }

        public String DepartmentId { get; set; }

        public String EmployeeId { get; set; }

        [UIHint("HiddenInput")]
        public bool IsSubmitted { get; set; }
        
    }
}
