using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AspCoreModule2.Models
{
    public partial class AirportContext : DbContext
    {
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Passenger> Passenger { get; set; }
        public virtual DbSet<PassInTrip> PassInTrip { get; set; }
        public virtual DbSet<Trip> Trip { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Airport;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.IdComp);

                entity.Property(e => e.IdComp)
                    .HasColumnName("ID_comp")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("char(10)");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.HasKey(e => e.IdPsg);

                entity.Property(e => e.IdPsg)
                    .HasColumnName("ID_psg")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("char(20)");
            });

            modelBuilder.Entity<PassInTrip>(entity =>
            {
                entity.HasKey(e => new { e.TripNo, e.Date, e.IdPsg });

                entity.ToTable("Pass_in_trip");

                entity.Property(e => e.TripNo).HasColumnName("trip_no");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPsg).HasColumnName("ID_psg");

                entity.Property(e => e.Place)
                    .IsRequired()
                    .HasColumnName("place")
                    .HasColumnType("char(10)");

                entity.HasOne(d => d.IdPsgNavigation)
                    .WithMany(p => p.PassInTrip)
                    .HasForeignKey(d => d.IdPsg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pass_in_trip_Passenger");

                entity.HasOne(d => d.TripNoNavigation)
                    .WithMany(p => p.PassInTrip)
                    .HasForeignKey(d => d.TripNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pass_in_trip_Trip");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasKey(e => e.TripNo);

                entity.Property(e => e.TripNo)
                    .HasColumnName("trip_no")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdComp).HasColumnName("ID_comp");

                entity.Property(e => e.Plane)
                    .IsRequired()
                    .HasColumnName("plane")
                    .HasColumnType("char(10)");

                entity.Property(e => e.TimeIn)
                    .HasColumnName("time_in")
                    .HasColumnType("datetime");

                entity.Property(e => e.TimeOut)
                    .HasColumnName("time_out")
                    .HasColumnType("datetime");

                entity.Property(e => e.TownFrom)
                    .IsRequired()
                    .HasColumnName("town_from")
                    .HasColumnType("char(25)");

                entity.Property(e => e.TownTo)
                    .IsRequired()
                    .HasColumnName("town_to")
                    .HasColumnType("char(25)");

                entity.HasOne(d => d.IdCompNavigation)
                    .WithMany(p => p.Trip)
                    .HasForeignKey(d => d.IdComp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trip_Company");
            });
        }
    }
}
