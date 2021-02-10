﻿// <auto-generated />
using System;
using DelegationBook.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DelegationBook.Migrations
{
    [DbContext(typeof(DelegationBookContext))]
    partial class DelegationBookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("DelegationBook.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("DelegationBook.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("DriverEmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("MainDriverEmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("MeterStatus")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarId");

                    b.HasIndex("DriverEmployeeId");

                    b.HasIndex("MainDriverEmployeeId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("DelegationBook.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.HasIndex("AddressId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("DelegationBook.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Division")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDriver")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Employee");
                });

            modelBuilder.Entity("DelegationBook.Models.KilometersCard", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("CardSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkCardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CardId");

                    b.HasIndex("CarId");

                    b.ToTable("KilometersCards");
                });

            modelBuilder.Entity("DelegationBook.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("DelegationBook.Models.Trip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DriverEmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("FinalMeter")
                        .HasColumnType("int");

                    b.Property<int>("InitialMeter")
                        .HasColumnType("int");

                    b.Property<int?>("KeeperEmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("KilometersCardCardId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("TripId");

                    b.HasIndex("DriverEmployeeId");

                    b.HasIndex("KeeperEmployeeId");

                    b.HasIndex("KilometersCardCardId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("DelegationBook.Models.Driver", b =>
                {
                    b.HasBaseType("DelegationBook.Models.Employee");

                    b.HasDiscriminator().HasValue("Driver");
                });

            modelBuilder.Entity("DelegationBook.Models.Car", b =>
                {
                    b.HasOne("DelegationBook.Models.Driver", null)
                        .WithMany("Cars")
                        .HasForeignKey("DriverEmployeeId");

                    b.HasOne("DelegationBook.Models.Employee", "MainDriver")
                        .WithMany()
                        .HasForeignKey("MainDriverEmployeeId");

                    b.Navigation("MainDriver");
                });

            modelBuilder.Entity("DelegationBook.Models.Company", b =>
                {
                    b.HasOne("DelegationBook.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("DelegationBook.Models.KilometersCard", b =>
                {
                    b.HasOne("DelegationBook.Models.Car", "Car")
                        .WithMany("KilometersCards")
                        .HasForeignKey("CarId");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("DelegationBook.Models.Project", b =>
                {
                    b.HasOne("DelegationBook.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("DelegationBook.Models.Trip", b =>
                {
                    b.HasOne("DelegationBook.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverEmployeeId");

                    b.HasOne("DelegationBook.Models.Employee", "Keeper")
                        .WithMany("Trips")
                        .HasForeignKey("KeeperEmployeeId");

                    b.HasOne("DelegationBook.Models.KilometersCard", "KilometersCard")
                        .WithMany("Trips")
                        .HasForeignKey("KilometersCardCardId");

                    b.HasOne("DelegationBook.Models.Project", "Project")
                        .WithMany("Trips")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Driver");

                    b.Navigation("Keeper");

                    b.Navigation("KilometersCard");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("DelegationBook.Models.Car", b =>
                {
                    b.Navigation("KilometersCards");
                });

            modelBuilder.Entity("DelegationBook.Models.Employee", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("DelegationBook.Models.KilometersCard", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("DelegationBook.Models.Project", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("DelegationBook.Models.Driver", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
