using DelegationBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelegationBook.Data
{
    public class DelegationBookContext : DbContext
    {
        public DelegationBookContext(DbContextOptions options) : base(options) { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<KilometersCard> KilometersCards { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Trip> Trips { get; set; }
    }
}
