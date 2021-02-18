using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DelegationBook.Models
{
    public class Employee : Person
    {
        [Key]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public int EmployeeId { get; set; }

        [Display(Name = "Stanowisko")]
        [StringLength(50, MinimumLength = 3, ErrorMessage ="Nazwa stanowiska musi mieć maksymalnie 50 znaków ale nie mniej niż 3")]
        public string Position { get; set; }

        [Display(Name = "Zadkład/Dział")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nazwa zakładu/działu musi mieć maksymalnie 50 znaków ale nie mniej niż 3")]
        public string Division { get; set; }

        [Display(Name = "Wyjazdy")]
        [NotMapped]
        public IEnumerable<Trip> Trips { get; set; }
        
        [Display(Name = "Kierowca")]
        public bool IsDriver { get; set; }
    }
}