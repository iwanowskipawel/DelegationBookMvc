using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DelegationBook.Models
{
    public class Car
    {
        [Key]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public int CarId { get; set; }

        [Display(Name = "Model")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Nazwa Modelu może mieć maksymalnie 20 znaków ale nie mniej niż 3")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public string Model { get; set; }

        [Display(Name = "Numer rejestracyjny")]
        [StringLength(9, ErrorMessage = "Numer rejestracyjny pojazdu nie może być dłuższy niż 9 znaków")]
        [RegularExpression(@"[A-Z0-9\s]+", ErrorMessage = "Numer rejestracyjny może zawierać tylko wielkie litery i cyfry")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Główny kierowca")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public Employee MainDriver { get; set; }

        [Display(Name = "Stan licznika")]
        [DisplayFormat(DataFormatString = "{0:N0} km")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        [RegularExpression(@"\d*", ErrorMessage = "Stan licznika należy podać w postaci liczby naturalnej")]
        public int MeterStatus { get; set; }

        [Display(Name = "Karty przejechanych km")]
        public IEnumerable<KilometersCard> KilometersCards { get; set; }

        public override string ToString() => $"{ Model } { RegistrationNumber }";
        
    }
}