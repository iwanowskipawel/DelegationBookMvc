using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DelegationBook.Models
{
    public class KilometersCard
    {
        [Key]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public int CardId { get; set; }

        [Display(Name = "Nr karty")]
        [StringLength(10, ErrorMessage = "Numer karty nie może być dłuższy niż 10 znaków")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public string CardSymbol { get; set; }

        [Display(Name = "Samochód")]
        public Car Car { get; set; }

        [Display(Name = "Karta pracy pojazdu")]
        [StringLength(10, ErrorMessage = "Numer karty nie może być dłuższy niż 10 znaków")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public string WorkCardNumber { get; set; }

        [Display(Name = "Wyjazdy")]
        public IEnumerable<Trip> Trips { get; set; }

        [Display(Name = "Przejechany dystans")]
        public int TotalDistance => Trips != null ? Trips.Sum(x => x.Distance) : 0;

        public override string ToString() => CardSymbol;

    }
}