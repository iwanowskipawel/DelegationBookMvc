using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelegationBook.Controllers
{
    public class TripsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List() => View();
    }
}
