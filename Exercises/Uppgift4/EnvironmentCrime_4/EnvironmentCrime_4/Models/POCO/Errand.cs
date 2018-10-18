using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EnvironmentCrime_4.Models
{
    /// <summary>
    /// Class for storing information about an errand
    /// Also includes data annotations that can be used in forms
    /// </summary>
    public class Errand
    {
        [Key]
        //Internal id in the database
        public int ErrandID{ get; set; }

        //år-45-löpnummer
        //Called errandId in the application
        public String RefNumber { get; set; }

        [Display(Name = "Var har brottet skett någonstans?")]
        [Required(ErrorMessage = "Du måste fylla i var brottet skett")]
        public String Place { get; set; }

        [Display(Name = "Vilken typ av brott?")]
        [Required(ErrorMessage = "Du måste fylla i typen av brott")]
        public String TypeOfCrime { get; set; }
        
        [Display(Name = "När skedde brottet?")]
        [UIHint("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Required(ErrorMessage = "Du måste fylla i när brottet skedde")]
        public DateTime DateOfObservation { get; set; }

        [Display(Name = "Beskriv din observation (ex. namn på misstänkt person):")]
        public String Observation { get; set; }

        [Display(Name = "Ingen åtgärd:")]
        public String InvestigatorAction { get; set; }

        [Display(Name = "Ange motivering")]
        public String InvestigatorInfo { get; set; }

        [Display(Name = "Ditt namn (för- och efternamn):")]
        [Required(ErrorMessage = "Du måste fylla i ditt namn")]
        public String InformerName { get; set; }

        [Display(Name = "Din telefon:")]
        [UIHint("PhonerNumber")]
		[RegularExpression(@"^[0]{1}[0-9]{1,3}-[0-9]{5,9}$", ErrorMessage = "Fyll i ett vettigt telefonnummer istället")]
        [Required(ErrorMessage = "Du måste fylle i ditt telefonnummer")]
        public String InformerPhone { get; set; }

        [ForeignKey("StatusId")]
        public String StatusId { get; set; }
        public ErrandStatus ErrandStatus { get; set; }
        
        [ForeignKey("DepartmentId")]
        public String DepartmentId { get; set; }
        public Department Department { get; set; }


        [ForeignKey("EmployeeId")]
        public String EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [NotMapped]
        [UIHint("HiddenInput")]
        public bool IsSubmitted { get; set; }

        public List<Picture> Pictures{ get; set; }

        public List<Sample> Samples { get; set; }

    }
}
