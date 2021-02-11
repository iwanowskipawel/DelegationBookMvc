using DelegationBook.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelegationBook.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DelegationBookContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DelegationBookContext>>()))
            {
                if (!context.Trips.Any())
                {
                    Employee employee1 = new Employee
                    {
                        FirstName = "Paweł",
                        LastName = "Iwanowski",
                        Position = "Inżynier",
                        Division = "Zakład Lotniskowy",
                        IsDriver = false
                    };

                    Employee employee2 = new Employee
                    {
                        FirstName = "Krzysztof",
                        LastName = "Blacha",
                        Position = "Kierownik Pracowni",
                        Division = "Zakład Lotniskowy",
                        IsDriver = false
                    };

                    Employee driver1 = new Employee
                    {
                        FirstName = "Wiesław",
                        LastName = "Eychler",
                        Position = "Technik",
                        Division = "Zakład Lotniskowy",
                        IsDriver = true
                    };

                    Employee driver2 = new Employee
                    {
                        FirstName = "Robert",
                        LastName = "Wesołowski",
                        Position = "Kierowca",
                        Division = "Transport",
                        IsDriver = true
                    };

                    context.Employees.AddRange(employee1, employee2, driver1, driver2);

                    Project project1 = new Project
                    {
                        Company = new Company
                        {
                            Address = new Address
                            {
                                City = "Warszawa",
                                PostalCode = "01-494",
                                Street = "Marszałkowska",
                                Number = "15/16"
                            },
                            Name = "Budexpol"
                        },
                        Symbol = "0-5519-24-1-00",
                        Title = "Budowa lotniska"
                    };

                    Project project2 = new Project
                    {
                        Company = new Company
                        {
                            Address = new Address
                            {
                                City = "Gdańsk",
                                PostalCode = "21-500",
                                Street = "Wiejska",
                                Number = "123"
                            },
                            Name = "Polbudex"
                        },
                        Symbol = "0-6512-24-1-00",
                        Title = "Remont DS"
                    };

                    context.Projects.AddRange(project1, project2);

                    Trip trip1 = new Trip
                    {
                        ArrivalDate = new DateTime(2021, 2, 4),
                        DepartureDate = new DateTime(2021, 2, 2),
                        Destination = "Kraków",
                        Keeper = employee1,
                        Driver = driver1,
                        Project = project1,
                        InitialMeter = 156444,
                        FinalMeter = 157375
                    };

                    Trip trip2 = new Trip
                    {
                        ArrivalDate = new DateTime(2021, 2, 4),
                        DepartureDate = new DateTime(2021, 2, 2),
                        Destination = "Poznań",
                        Keeper = employee2,
                        Driver = driver2,
                        Project = project2,
                        InitialMeter = 157375,
                        FinalMeter = 158456
                    };

                    context.Trips.AddRange(trip1, trip2);
                    context.SaveChanges();
                }
            }
        }
    }
}
