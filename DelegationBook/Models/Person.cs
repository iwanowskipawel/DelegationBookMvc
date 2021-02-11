using System.ComponentModel.DataAnnotations;

namespace DelegationBook.Models
{
    public abstract class Person
    {
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Display(Name = "Nazwisko i imię")]
        public string FullName => $" { LastName } { FirstName }";

        public override string ToString() => FullName;
        
    }
}