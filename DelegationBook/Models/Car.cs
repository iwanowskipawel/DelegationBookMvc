using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DelegationBook.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name = "Numer rejestracyjny")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Główny kierowca")]
        public Employee MainDriver { get; set; }

        [Display(Name = "Stan licznika")]
        public int MeterStatus { get; set; }

        [Display(Name = "Karty przejechanych km")]
        public IEnumerable<KilometersCard> KilometersCards { get; set; }

        public override string ToString() => $"{ Model } { RegistrationNumber }";
        
    }
}