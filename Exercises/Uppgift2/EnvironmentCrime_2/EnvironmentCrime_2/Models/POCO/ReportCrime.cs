using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EnvironmentCrime_2.Models
{
    public class ReportCrime
    {

        [UIHint("HiddenInput")]
        public bool IsSubmitted { get; set; }

        [Display(Name = "Var har brottet skett någonstans?")]
        [Required(ErrorMessage ="Du måste fylla i var brottet skett")]
        public String Place { get; set; }

        [Display(Name ="Vilken typ av brott?")]
        [Required(ErrorMessage ="Du måste fylla i typen av brott")]
        public String Crime { get; set; }

        [Display (Name = "När skedde brottet?")]
        [UIHint("Date")]
        [Required(ErrorMessage = "Du måste fylla i när brottet skedde")]
        public String CrimeDate { get; set; }

        [Display(Name = "Ditt namn (för- och efternamn):")]
        [Required(ErrorMessage = "Du måste fylla i ditt namn")]
        public String InformersName { get; set; }

        [Display (Name = "Din telefon:")]
        [UIHint("PhonerNumber")]
        [RegularExpression(@"^[0]{1}[0-9]{1,3}-[0-9]{5,9}$")]
        [Required(ErrorMessage ="Du måste fylle i ditt telefonnummer")]
        public String Phone { get; set; }

        [Display(Name ="Beskriv din observation<br /> (ex. namn på misstänkt person):")]
        public String Observation { get; set; }



    }
}
