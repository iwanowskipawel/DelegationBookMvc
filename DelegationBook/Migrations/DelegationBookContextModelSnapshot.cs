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
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("DelegationBook.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("MainDriverEmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("MeterStatus")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("CarId");

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
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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

                    b.Property<string>("Division")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsDriver")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Position")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
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
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("WorkCardNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

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
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

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
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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

            modelBuilder.Entity("DelegationBook.Models.Car", b =>
                {
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
                    b.HasOne("DelegationBook.Models.Employee", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverEmployeeId");

                    b.HasOne("DelegationBook.Models.Employee", "Keeper")
                        .WithMany()
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

            modelBuilder.Entity("DelegationBook.Models.KilometersCard", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("DelegationBook.Models.Project", b =>
                {
                    b.Navigation("Trips");
                });
#pragma warning restore 612, 618
        }
    }
}
