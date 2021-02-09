using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DelegationBook.Models
{
    public class Driver : Employee
    {
        
        public int DriverId { get; set; }

        [Display(Name = "Użytkowane samochody")]
        public IEnumerable<Car> Cars { get; set; }
    }
}