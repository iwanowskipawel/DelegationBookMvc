using System.ComponentModel.DataAnnotations;

namespace DelegationBook.Models
{
    public class Address
    {
        [Key]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public int AddressId { get; set; }

        [Display(Name = "Ulica")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nazwa ulicy może mieć maksymalnie 50 znaków ale nie mniej niż 3")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public string Street { get; set; }

        [Display(Name = "Numer")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Numer może mieć maksymalnie 10 znaków ale nie mniej niż 1")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public string Number { get; set; }

        [Display(Name = "Miejscowość")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nazwa miejscowości może mieć maksymalnie 50 znaków ale nie mniej niż 3")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public string City { get; set; }

        [Display(Name = "Kod pocztowy")]
        [RegularExpression(@"\d{2}-\d{3}", ErrorMessage = "Kod pocztowy należy podać w formacie 00-000")]
        [StringLength(6)]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public string PostalCode { get; set; }

        public override string ToString() => $"{ Street } { Number }, { PostalCode } { City }";
    }
}