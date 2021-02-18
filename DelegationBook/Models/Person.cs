using System.ComponentModel.DataAnnotations;

namespace DelegationBook.Models
{
    public abstract class Person
    {
        [Display(Name = "Imię")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Imię musi mieć maksymalnie 20 znaków ale nie mniej niż 3")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nazwisko musi mieć maksymalnie 50 znaków ale nie mniej niż 3")]
        public string LastName { get; set; }

        [Display(Name = "Nazwisko i imię")]
        public string FullName => $" { LastName } { FirstName }";

        public override string ToString() => FullName;
        
    }
}