using DelegationBook.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelegationBook.Models.ViewModels
{
    public class TripViewModel
    {
        public Trip Trip { get; set; }
        public Employee SelectedEmployee { get; set; }
        public SelectList Employees { get; set; }
    }
}
