using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DelegationBook.Models
{
    public class Employee : Person
    {
        [Key]
        public int EmployeeId { get; set; }

        public string Position { get; set; }
        public string Division { get; set; }


        [Display(Name = "Wyjazdy")]
        public IEnumerable<Trip> Trips { get; set; }
    }
}