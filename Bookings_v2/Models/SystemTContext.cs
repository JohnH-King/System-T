using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bookings_v2.Models
{
    public partial class SystemTContext : DbContext
    {
        public SystemTContext()
        {
        }

        public SystemTContext(DbContextOptions<SystemTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accommodation> Accommodations { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Flight> Flights { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<Transport> Transports { get; set; } = null!;
        public virtual DbSet<TransportType> TransportTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=systemtise.csp1vikprmva.us-east-2.rds.amazonaws.com;Database=SystemT;User Id=admin;Password=SystemTTravel;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accommodation>(entity =>
            {
                entity.ToTable("Accommodation");

                entity.Property(e => e.AccommodationId)
                    .ValueGeneratedNever()
                    .HasColumnName("Accommodation_ID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ImageId).HasColumnName("image_ID");

                entity.Property(e => e.Location)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId)
                    .ValueGeneratedNever()
                    .HasColumnName("Booking_ID");

                entity.Property(e => e.AccomodationId).HasColumnName("Accomodation_ID");

                entity.Property(e => e.FllightId).HasColumnName("Fllight_ID");

                entity.Property(e => e.TransactionId).HasColumnName("Transaction_ID");

                entity.Property(e => e.TransactionTotal).HasColumnName("Transaction_Total");

                entity.Property(e => e.TransportId).HasColumnName("Transport_ID");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.ClientId)
                    .ValueGeneratedNever()
                    .HasColumnName("Client_ID");

                entity.Property(e => e.CellNumber)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("Flight");

                entity.Property(e => e.FlightId)
                    .ValueGeneratedNever()
                    .HasColumnName("Flight_ID");

                entity.Property(e => e.Cost)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.DepartureDate).HasColumnType("datetime");

                entity.Property(e => e.EndLocation)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ImageId).HasColumnName("Image_ID");

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.Property(e => e.StartLocation)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.ClientLoginId);

                entity.ToTable("Login");

                entity.Property(e => e.ClientLoginId)
                    .ValueGeneratedNever()
                    .HasColumnName("ClientLogin_ID");

                entity.Property(e => e.Admin)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction");

                entity.Property(e => e.TransactionId)
                    .ValueGeneratedNever()
                    .HasColumnName("Transaction_ID");
            });

            modelBuilder.Entity<Transport>(entity =>
            {
                entity.ToTable("Transport");

                entity.Property(e => e.TransportId)
                    .ValueGeneratedNever()
                    .HasColumnName("Transport_ID");

                entity.Property(e => e.BookingId).HasColumnName("Booking_ID");

                entity.Property(e => e.EndLocation)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ImageId)
                    .HasMaxLength(10)
                    .HasColumnName("Image_ID")
                    .IsFixedLength();

                entity.Property(e => e.StartLocation)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TypeId).HasColumnName("Type_ID");
            });

            modelBuilder.Entity<TransportType>(entity =>
            {
                entity.ToTable("TransportType");

                entity.Property(e => e.TransportTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("TransportType_ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
