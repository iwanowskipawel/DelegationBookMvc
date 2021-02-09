using System.ComponentModel.DataAnnotations;

namespace DelegationBook.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Adres")]
        public Address Address { get; set; }

        public override string ToString() => Name;
        
    }
}