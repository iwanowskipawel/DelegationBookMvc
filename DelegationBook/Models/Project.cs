using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DelegationBook.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Display(Name = "Symbol")]
        public string Symbol { get; set; }

        [Display(Name = "Zamawiający")]
        public Company Company { get; set; }

        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Display(Name = "Wyjazdy")]
        public IEnumerable<Trip> Trips { get; set; }

        public override string ToString() => Symbol;
    }
}