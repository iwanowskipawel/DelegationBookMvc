using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DelegationBook.Models
{
    public class Employee : Person
    {
        [Key]
        public int EmployeeId { get; set; }

        [Display(Name = "Stanowisko")]
        public string Position { get; set; }

        [Display(Name = "Zadkład/Dział")]
        public string Division { get; set; }


        [Display(Name = "Wyjazdy")]
        [NotMapped]
        public IEnumerable<Trip> Trips { get; set; }
        
        [Display(Name = "Kierowca")]
        public bool IsDriver { get; set; }
    }
}