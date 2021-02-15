using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DelegationBook.Models
{
    public class KilometersCard
    {
        [Key]
        public int CardId { get; set; }

        [Display(Name = "Nr karty")]
        public string CardSymbol { get; set; }

        [Display(Name = "Samochód")]
        public Car Car { get; set; }

        [Display(Name = "Karta pracy pojazdu")]
        public string WorkCardNumber { get; set; }

        [Display(Name = "Wyjazdy")]
        public IEnumerable<Trip> Trips { get; set; }

        [Display(Name = "Przejechany dystans")]
        public int TotalDistance => Trips.Count() > 0 ? Trips.Sum(x => x.Distance) : 0;

        public override string ToString() => CardSymbol;

    }
}