﻿using System.ComponentModel.DataAnnotations;

namespace DelegationBook.Models
{
    public class Address
    {
        [Key]
        [Required(ErrorMessage = "Pole obowiązkowe")]
        public int AddressId { get; set; }

        [Display(Name = "Ulica")]
        public string Street { get; set; }

        [Display(Name = "Numer")]
        public string Number { get; set; }

        [Display(Name = "Miejscowość")]
        public string City { get; set; }

        [Display(Name = "Kod pocztowy")]
        public string PostalCode { get; set; }

        public override string ToString() => $"{ Street } { Number }, { PostalCode } { City }";
    }
}