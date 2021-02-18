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
        [DisplayFormat(DataFormatString ="{0:dd.MM.yyyy} r.")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public DateTime DepartureDate { get; set; }

        [Display(Name = "Data powrotu")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy} r.")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public DateTime ArrivalDate { get; set; }

        [Display(Name = "Kierowca")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public Employee Driver { get; set; }

        [Display(Name = "Temat")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public Project Project { get; set; }

        [Display(Name = "Dysponent")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public Employee Keeper { get; set; }

        [Display(Name = "Miejsce docelowe")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nazwa miejsca docelowego musi mieć maksymalnie 50 znaków ale nie mniej niż 3")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public string Destination { get; set; }

        [Display(Name = "Początkowy stan licznika")]
        [DisplayFormat(DataFormatString = "{0:N0} km")]
        [RegularExpression(@"\d*", ErrorMessage = "Stan licznika należy podać w postaci liczby naturalnej")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public int InitialMeter { get; set; }

        [Display(Name = "Końcowy stan licznika")]
        [DisplayFormat(DataFormatString = "{0:N0} km")]
        [RegularExpression(@"\d*", ErrorMessage = "Stan licznika należy podać w postaci liczby naturalnej")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public int FinalMeter { get; set; }

        [Display(Name = "Dystans")]
        [DisplayFormat(DataFormatString = "{0:N0} km")]
        public int Distance => FinalMeter - InitialMeter;

        [Display(Name = "Karta kilometrów")]
        public KilometersCard KilometersCard { get; set; }

        public override string ToString() => $"{Destination} - {DepartureDate}-{ArrivalDate}";
    }
}
