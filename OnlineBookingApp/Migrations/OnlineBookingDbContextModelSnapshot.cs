﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineBookingApp.Data;

#nullable disable

namespace OnlineBookingApp.Migrations
{
    [DbContext(typeof(OnlineBookingDbContext))]
    partial class OnlineBookingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OnlineBookingApp.Models.Booking.BookingGuest", b =>
                {
                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("CarRentalId")
                        .HasColumnType("int");

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.HasIndex("CarRentalId");

                    b.HasIndex("FlightId");

                    b.HasIndex("HotelId");

                    b.ToTable("BookingGuest");
                });

            modelBuilder.Entity("OnlineBookingApp.Models.Booking.CarRental", b =>
                {
                    b.Property<int>("CarRentalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarRentalId"), 1L, 1);

                    b.Property<string>("CarModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RentalCompany")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarRentalId");

                    b.ToTable("cars");
                });

            modelBuilder.Entity("OnlineBookingApp.Models.Booking.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"), 1L, 1);

                    b.Property<string>("Airline")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("FlightId");

                    b.ToTable("flights");
                });

            modelBuilder.Entity("OnlineBookingApp.Models.Booking.Guest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("guest");
                });

            modelBuilder.Entity("OnlineBookingApp.Models.Booking.GuestBooking", b =>
                {
                    b.Property<int>("GuestBookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GuestBookingId"), 1L, 1);

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.HasKey("GuestBookingId");

                    b.ToTable("guestBooking");
                });

            modelBuilder.Entity("OnlineBookingApp.Models.Booking.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotelId"), 1L, 1);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("HotelId");

                    b.ToTable("hotels");
                });

            modelBuilder.Entity("OnlineBookingApp.Models.Booking.BookingGuest", b =>
                {
                    b.HasOne("OnlineBookingApp.Models.Booking.CarRental", "CarRental")
                        .WithMany()
                        .HasForeignKey("CarRentalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineBookingApp.Models.Booking.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineBookingApp.Models.Booking.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarRental");

                    b.Navigation("Flight");

                    b.Navigation("Hotel");
                });
#pragma warning restore 612, 618
        }
    }
}
