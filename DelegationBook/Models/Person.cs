using System.ComponentModel.DataAnnotations;

namespace DelegationBook.Models
{
    public abstract class Person
    {
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Display(Name = "Imię i nazwisko")]
        public string FullName => $"{ FirstName } { LastName }";

        public override string ToString() => FullName;
        
    }
}