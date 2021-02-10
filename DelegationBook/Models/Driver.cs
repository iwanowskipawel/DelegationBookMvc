using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelegationBook.Models
{
    public class Driver : Employee
    {
        public IEnumerable<Car> Cars { get; set; }
    }
}
