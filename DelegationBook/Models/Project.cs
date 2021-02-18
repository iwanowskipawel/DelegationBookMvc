
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DelegationBook.Models
{
    public class Project
    {
        [Key]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public int ProjectId { get; set; }

        [Display(Name = "Symbol")]
        [RegularExpression(@"\d{1}-\d{4}-\d{2}-\d{1}-\d{2}", ErrorMessage ="Symbol tematu musi być w formacie 0-0000-00-0-00")]
        [StringLength(14)]
        [Required(ErrorMessage ="Pole obowiązkowe")]
        public string Symbol { get; set; }

        [Display(Name = "Zamawiający")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public Company Company { get; set; }

        [Display(Name = "Tytuł")]
        [StringLength(100, MinimumLength = 3, ErrorMessage ="Tytuł tematu musi mieć maksymalnie 100 znaków ale nie mniej niż 3")]
        [RegularExpression(@"^[A-Z].*", ErrorMessage ="Tytuł poiwnien rozpoczynać się wielką literą")]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public string Title { get; set; }

        [Display(Name = "Wyjazdy")]
        public IEnumerable<Trip> Trips { get; set; }

        public override string ToString() => Symbol;
    }
}