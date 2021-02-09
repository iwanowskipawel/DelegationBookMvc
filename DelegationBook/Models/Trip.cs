using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DelegationBook.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }

        [Display(Name = "Data wyjazdu")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0} r.")]
        public DateTime DepartureDate { get; set; }

        [Display(Name = "Data powrotu")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0} r.")]
        public DateTime ArrivalDate { get; set; }

        [Display(Name = "Kierowca")]
        public Driver Driver { get; set; }

        [Display(Name = "Temat")]
        public Project Project { get; set; }

        [Display(Name = "Dysponent")]
        public Employee Keeper { get; set; }

        [Display(Name = "Miejsce docelowe")]
        public string Destination { get; set; }

        [Display(Name = "Początkowy stan licznika")]
        public int InitialMeter { get; set; }

        [Display(Name = "Końcowy stan licznika")]
        public int FinalMeter { get; set; }

        [Display(Name = "Dystans")]
        public int Distance => FinalMeter - InitialMeter;

        public KilometersCard KilometersCard { get; set; }

        public override string ToString() => $"{Destination} - {DepartureDate}-{ArrivalDate}";
    }
}
