﻿// <auto-generated />
using System;
using AM.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AM.Infra.Migrations
{
    [DbContext(typeof(AMContext))]
    [Migration("20240228105421_annotation2")]
    partial class annotation2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AM.applicationcore.Domain.Flight", b =>
                {
                    b.Property<int>("Flightid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Flightid"));

                    b.Property<string>("Departure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EffectiveArrival")
                        .HasColumnType("datetime2");

                    b.Property<int>("EstimationDuration")
                        .HasColumnType("int");

                    b.Property<DateTime>("FlightDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlaneFK")
                        .HasColumnType("int");

                    b.HasKey("Flightid");

                    b.HasIndex("PlaneFK");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("AM.applicationcore.Domain.Passenger", b =>
                {
                    b.Property<string>("PassportNumber")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TelNumber")
                        .HasColumnType("int");

                    b.HasKey("PassportNumber");

                    b.ToTable("Passengers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Passenger");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AM.applicationcore.Domain.Plane", b =>
                {
                    b.Property<int>("Planeid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Planeid"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("ManufactureDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlaneType")
                        .HasColumnType("int");

                    b.Property<string>("airlineLogo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Planeid");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("FlightPassenger", b =>
                {
                    b.Property<int>("FlightsFlightid")
                        .HasColumnType("int");

                    b.Property<string>("passengersPassportNumber")
                        .HasColumnType("nvarchar(7)");

                    b.HasKey("FlightsFlightid", "passengersPassportNumber");

                    b.HasIndex("passengersPassportNumber");

                    b.ToTable("FlightPassenger");
                });

            modelBuilder.Entity("AM.applicationcore.Domain.Staff", b =>
                {
                    b.HasBaseType("AM.applicationcore.Domain.Passenger");

                    b.Property<DateTime>("EmployemenDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Function")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("Staff");
                });

            modelBuilder.Entity("AM.applicationcore.Domain.Traveller", b =>
                {
                    b.HasBaseType("AM.applicationcore.Domain.Passenger");

                    b.Property<string>("HealthInformation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Traveller");
                });

            modelBuilder.Entity("AM.applicationcore.Domain.Flight", b =>
                {
                    b.HasOne("AM.applicationcore.Domain.Plane", "p")
                        .WithMany("flights")
                        .HasForeignKey("PlaneFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("p");
                });

            modelBuilder.Entity("AM.applicationcore.Domain.Passenger", b =>
                {
                    b.OwnsOne("AM.applicationcore.Domain.FullName", "fullName", b1 =>
                        {
                            b1.Property<string>("PassengerPassportNumber")
                                .HasColumnType("nvarchar(7)");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(25)
                                .HasColumnType("nvarchar(25)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PassengerPassportNumber");

                            b1.ToTable("Passengers");

                            b1.WithOwner()
                                .HasForeignKey("PassengerPassportNumber");
                        });

                    b.Navigation("fullName")
                        .IsRequired();
                });

            modelBuilder.Entity("FlightPassenger", b =>
                {
                    b.HasOne("AM.applicationcore.Domain.Flight", null)
                        .WithMany()
                        .HasForeignKey("FlightsFlightid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AM.applicationcore.Domain.Passenger", null)
                        .WithMany()
                        .HasForeignKey("passengersPassportNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AM.applicationcore.Domain.Plane", b =>
                {
                    b.Navigation("flights");
                });
#pragma warning restore 612, 618
        }
    }
}