using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bookings.Models
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

        public virtual DbSet<Accomodation> Accomodations { get; set; } = null!;
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
                optionsBuilder.UseSqlServer("Server=DESKTOP-P04GS2M\\SQLEXPRESS;Database=SystemT;User Id=ian;Password=6991;Trusted_Connection=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accomodation>(entity =>
            {
                entity.ToTable("Accomodation");

                entity.Property(e => e.AccomodationId).ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Location).HasMaxLength(30);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId).ValueGeneratedNever();

                entity.HasOne(d => d.Accomodation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.AccomodationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__Accomod__48CFD27E");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__FlightI__49C3F6B7");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__Transac__4AB81AF0");

                entity.HasOne(d => d.Transport)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.TransportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__Transpo__47DBAE45");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.ClientId).ValueGeneratedNever();

                entity.Property(e => e.CellNumber).HasMaxLength(5);

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.HasOne(d => d.ClientLogin)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.ClientLoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Client__ClientLo__398D8EEE");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("Flight");

                entity.Property(e => e.FlightId).ValueGeneratedNever();

                entity.Property(e => e.DepartureDate).HasColumnType("datetime");

                entity.Property(e => e.EndLocation).HasMaxLength(30);

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.Property(e => e.StartLocation).HasMaxLength(30);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.ClientLoginId)
                    .HasName("PK__Login__64B6D3CEAE0CEB49");

                entity.ToTable("Login");

                entity.Property(e => e.ClientLoginId).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.IsAdmin)
                    .HasMaxLength(5)
                    .HasColumnName("isAdmin");

                entity.Property(e => e.Password).HasMaxLength(30);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.TransactionId).ValueGeneratedNever();

                entity.Property(e => e.Approved).HasColumnName("approved");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Clien__3C69FB99");
            });

            modelBuilder.Entity<Transport>(entity =>
            {
                entity.ToTable("Transport");

                entity.Property(e => e.TransportId).ValueGeneratedNever();

                entity.Property(e => e.EndLocation).HasMaxLength(30);

                entity.Property(e => e.StartLocation).HasMaxLength(30);

                entity.HasOne(d => d.TransportType)
                    .WithMany(p => p.Transports)
                    .HasForeignKey(d => d.TransportTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transport__Trans__44FF419A");
            });

            modelBuilder.Entity<TransportType>(entity =>
            {
                entity.ToTable("TransportType");

                entity.Property(e => e.TransportTypeId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
