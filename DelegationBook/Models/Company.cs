using System.ComponentModel.DataAnnotations;

namespace DelegationBook.Models
{
    public class Company
    {
        [Key]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public int CompanyId { get; set; }

        [Display(Name = "Nazwa")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nazwa firmy może mieć maksymalnie 50 znaków ale nie mniej niż 3")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public string Name { get; set; }

        [Display(Name = "Adres")]
        public Address Address { get; set; }

        public override string ToString() => Name;
        
    }
}