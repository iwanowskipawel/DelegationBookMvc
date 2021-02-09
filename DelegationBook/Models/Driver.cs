using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DelegationBook.Models
{
    public class Driver : Employee
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Użytkowane samochody")]
        public IEnumerable<Car> Cars { get; set; }
    }
}