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

                    Address address1 = new Address
                    {
                        City = "Warszawa",
                        PostalCode = "01-494",
                        Street = "Marszałkowska",
                        Number = "15/16"
                    };

                    Address address2 = new Address
                    {
                        City = "Gdańsk",
                        PostalCode = "21-500",
                        Street = "Wiejska",
                        Number = "123"
                    };

                    context.Addresses.AddRange(address1, address2);

                    Company company1 = new Company
                    {
                        Address = address1,
                        Name = "Budexpol"
                    };

                    Company company2 = new Company
                    {
                        Address = address2,
                        Name = "Polbudex"
                    };

                    context.Companies.AddRange(company1, company2);

                    Project project1 = new Project
                    {
                        Company = company1,
                        Symbol = "0-5519-24-1-00",
                        Title = "Budowa lotniska"
                    };

                    Project project2 = new Project
                    {
                        Company = company2,
                        Symbol = "0-6512-24-1-00",
                        Title = "Remont DS"
                    };

                    context.Projects.AddRange(project1, project2);

                    Car car1 = new Car
                    {
                        MainDriver = driver1,
                        MeterStatus = 354124,
                        Model = "Ford Transit",
                        RegistrationNumber = "WB 65788"
                    };

                    Car car2 = new Car
                    {
                        MainDriver = driver2,
                        MeterStatus = 276345,
                        Model = "Ford Transit",
                        RegistrationNumber = "WB 9135F"
                    };

                    context.Cars.AddRange(car1, car2);

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

                    Trip trip3 = new Trip
                    {
                        ArrivalDate = new DateTime(2021, 2, 9),
                        DepartureDate = new DateTime(2021, 2, 8),
                        Destination = "Gdańsk",
                        Keeper = employee2,
                        Driver = driver1,
                        Project = project2,
                        InitialMeter = 158456,
                        FinalMeter = 159456
                    };

                    context.Trips.AddRange(trip1, trip2, trip3);

                    KilometersCard card1 = new KilometersCard
                    {
                        Car = car1,
                        CardSymbol = "7/2020",
                        Trips = new Trip[] { trip1 },
                        WorkCardNumber = "123"
                    };

                    KilometersCard card2 = new KilometersCard
                    {
                        Car = car2,
                        CardSymbol = "12/2020",
                        Trips = new Trip[] { trip2, trip3 },
                        WorkCardNumber = "45"
                    };

                    context.KilometersCards.AddRange(card1, card2);

                    context.SaveChanges();
                }
            }
        }
    }
}
