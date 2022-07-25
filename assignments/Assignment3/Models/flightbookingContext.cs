using System;
using System.Collections.Generic;
using Assignment3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assignment3.Models 
{ 
    public partial class flightbookingContext : DbContext
    {
       
        public flightbookingContext(DbContextOptions<flightbookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airline> Airlines { get; set; } = null!;
        public virtual DbSet<Airplane> Airplanes { get; set; } = null!;
        public virtual DbSet<Airport> Airports { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<ContactDetail> ContactDetails { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<FlightInstance> FlightInstances { get; set; } = null!;
        public virtual DbSet<Passenger> Passengers { get; set; } = null!;
        public virtual DbSet<Assignment3.Models.Route> Routes { get; set; } = null!;
        public virtual DbSet<RoutePlane> RoutePlanes { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=flightbooking;Trusted_Connection=true;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airline>(entity =>
            {
                entity.HasKey(e => e.AirlineCode);

                entity.ToTable("Airline");

                entity.Property(e => e.AirlineCode)
                    .ValueGeneratedNever()
                    .HasColumnName("Airline_code");

                entity.Property(e => e.AirlineName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Airline_name");
            });

            modelBuilder.Entity<Airplane>(entity =>
            {
                entity.ToTable("Airplane");

                entity.Property(e => e.AirplaneId)
                    .ValueGeneratedNever()
                    .HasColumnName("Airplane_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Airplane_name");

                entity.Property(e => e.BSeats).HasColumnName("B_seats");

                entity.Property(e => e.ESeats).HasColumnName("E_seats");

                entity.Property(e => e.FSeats).HasColumnName("F_seats");
            });

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.HasKey(e => e.IataAirportCode);

                entity.ToTable("Airport");

                entity.Property(e => e.IataAirportCode)
                    .ValueGeneratedNever()
                    .HasColumnName("Airport_code");

                entity.Property(e => e.AirportName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Airport_name");

                entity.Property(e => e.CityCode).HasColumnName("City_code");

                entity.Property(e => e.CountryCode).HasColumnName("Country_code");

                entity.HasOne(d => d.CityCodeNavigation)
                    .WithMany(p => p.Airports)
                    .HasForeignKey(d => d.CityCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Airport_City");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Airports)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Airport_Country");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.IataCityCode);

                entity.ToTable("City");

                entity.Property(e => e.IataCityCode)
                    .ValueGeneratedNever()
                    .HasColumnName("City_code");

                entity.Property(e => e.CityName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("City_name");

                entity.Property(e => e.CountryCode).HasColumnName("Country_code");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_Country");
            });

            modelBuilder.Entity<ContactDetail>(entity =>
            {
                entity.HasKey(e => e.ContactId);

                entity.ToTable("Contact_details");

                entity.Property(e => e.ContactId)
                    .ValueGeneratedNever()
                    .HasColumnName("Contact_id");

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryIataCode);

                entity.ToTable("Country");

                entity.Property(e => e.CountryIataCode)
                    .ValueGeneratedNever()
                    .HasColumnName("Country_code");

                entity.Property(e => e.CountryName).HasColumnName("Country_name");
            });

            modelBuilder.Entity<FlightInstance>(entity =>
            {
                entity.HasKey(e => e.InstanceId);

                entity.ToTable("Flight_Instances");

                entity.Property(e => e.InstanceId)
                    .ValueGeneratedNever()
                    .HasColumnName("Instance_id");

                entity.Property(e => e.Arrival).HasColumnType("smalldatetime");

                entity.Property(e => e.BCost).HasColumnName("B_cost");

                entity.Property(e => e.BSeats).HasColumnName("B_seats");

                entity.Property(e => e.Departure).HasColumnType("smalldatetime");

                entity.Property(e => e.ECost).HasColumnName("E_cost");

                entity.Property(e => e.ESeats).HasColumnName("E_seats");

                entity.Property(e => e.FCost).HasColumnName("F_cost");

                entity.Property(e => e.FSeats).HasColumnName("F_seats");

                entity.Property(e => e.PlaneId).HasColumnName("Plane_id");

                entity.Property(e => e.RouteId).HasColumnName("Route_id");

                entity.HasOne(d => d.Plane)
                    .WithMany(p => p.FlightInstances)
                    .HasForeignKey(d => d.PlaneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flight_Instances_Airplane");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.FlightInstances)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flight_Instances_Route_plane");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.Property(e => e.PassengerId)
                    .ValueGeneratedNever()
                    .HasColumnName("Passenger_id");

                entity.Property(e => e.Age)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cancelled)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Confirmed)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Email_id");

                entity.Property(e => e.FlightInstId).HasColumnName("Flight_inst_id");

                entity.Property(e => e.PassengerName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Passenger_name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SeatNo).HasColumnName("Seat_no");

                entity.Property(e => e.Sex)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.FlightInst)
                    .WithMany(p => p.Passengers)
                    .HasForeignKey(d => d.FlightInstId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Passengers_Flight_Instances");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Passengers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Passengers_Users");
            });

            modelBuilder.Entity<Assignment3.Models.Route>(entity =>
            {
                entity.Property(e => e.RouteId)
                    .ValueGeneratedNever()
                    .HasColumnName("Route_id");

                entity.Property(e => e.AirlineCode).HasColumnName("Airline_code");

                entity.Property(e => e.ArrivalAirportCode).HasColumnName("Arrival_airport_code");

                entity.Property(e => e.DeparureAirportCode).HasColumnName("Departure_airport_code");

                entity.HasOne(d => d.AirlineCodeNavigation)
                    .WithMany(p => p.Routes)
                    .HasForeignKey(d => d.AirlineCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Routes_Airline");

                entity.HasOne(d => d.ArrivalAirportCodeNavigation)
                    .WithMany(p => p.RouteArrivalAirportCodeNavigations)
                    .HasForeignKey(d => d.ArrivalAirportCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Routes_Airport");

                entity.HasOne(d => d.DeparureAirportCodeNavigation)
                    .WithMany(p => p.RouteDeparureAirportCodeNavigations)
                    .HasForeignKey(d => d.DeparureAirportCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Routes_Airport1");
            });

            modelBuilder.Entity<RoutePlane>(entity =>
            {
                entity.HasKey(e => e.RouteId);

                entity.ToTable("Route_plane");

                entity.Property(e => e.RouteId)
                    .ValueGeneratedNever()
                    .HasColumnName("Route_id");

                entity.Property(e => e.PlaneId).HasColumnName("Plane_id");

                entity.HasOne(d => d.Plane)
                    .WithMany(p => p.RoutePlanes)
                    .HasForeignKey(d => d.PlaneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Route_plane_Airplane");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("Order_id");

                entity.Property(e => e.Date).HasColumnType("smalldatetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transactions_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("User_id");

                entity.Property(e => e.ContactId).HasColumnName("Contact_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("User_name");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Contact_details");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
