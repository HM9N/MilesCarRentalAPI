using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MilesCarRentalApi.Context.MilesCarModels;

namespace MilesCarRentalApi.Context;

public partial class MilesCarRentalDbContext : DbContext
{
    public MilesCarRentalDbContext()
    {
    }

    public MilesCarRentalDbContext(DbContextOptions<MilesCarRentalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("PK__CLIENTS__6EC2B6C0DBBF226A");

            entity.ToTable("CLIENTS");

            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.IdLocation).HasName("PK__LOCATION__276C0C69BAF7EA60");

            entity.ToTable("LOCATIONS");

            entity.Property(e => e.IdLocation).HasColumnName("id_location");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.IdRental).HasName("PK__RENTALS__EE7436FE9AF0E2C9");

            entity.ToTable("RENTALS");

            entity.Property(e => e.IdRental).HasColumnName("id_rental");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdPickupLocation).HasColumnName("id_pickup_location");
            entity.Property(e => e.IdReturnLocation).HasColumnName("id_return_location");
            entity.Property(e => e.IdVehicle).HasColumnName("id_vehicle");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RENTALS__id_clie__3E52440B");

            entity.HasOne(d => d.IdPickupLocationNavigation).WithMany(p => p.RentalIdPickupLocationNavigations)
                .HasForeignKey(d => d.IdPickupLocation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RENTALS__id_pick__403A8C7D");

            entity.HasOne(d => d.IdReturnLocationNavigation).WithMany(p => p.RentalIdReturnLocationNavigations)
                .HasForeignKey(d => d.IdReturnLocation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RENTALS__id_retu__412EB0B6");

            entity.HasOne(d => d.IdVehicleNavigation).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.IdVehicle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RENTALS__id_vehi__3F466844");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.IdVehicle).HasName("PK__VEHICLES__6DF73CE41CD54E9E");

            entity.ToTable("VEHICLES");

            entity.Property(e => e.IdVehicle).HasColumnName("id_vehicle");
            entity.Property(e => e.Availability)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("availability");
            entity.Property(e => e.Brand)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("brand");
            entity.Property(e => e.IdLocation).HasColumnName("id_location");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("model");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasOne(d => d.IdLocationNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.IdLocation)
                .HasConstraintName("FK__VEHICLES__id_loc__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
