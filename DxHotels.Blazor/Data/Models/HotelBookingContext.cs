using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DxHotels.Blazor.Data.Models;

public partial class HotelBookingContext : DbContext
{
    public HotelBookingContext()
    {
    }

    public HotelBookingContext(DbContextOptions<HotelBookingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Features_List> Features_Lists { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Hotel_Feature> Hotel_Features { get; set; }

    public virtual DbSet<Hotel_Image> Hotel_Images { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Metro_Area> Metro_Areas { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Room_Feature> Room_Features { get; set; }
    public virtual DbSet<Room_Type> Room_Types { get; set; }
    public virtual DbSet<Room> Rooms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.Property(e => e.City_Image).HasMaxLength(50);
            entity.Property(e => e.State_Province).HasMaxLength(50);

            entity.HasOne(d => d.Metro_Area).WithMany(p => p.Cities)
                .HasForeignKey(d => d.Metro_Area_ID)
                .HasConstraintName("FK_Cities_Metro_Areas");
        });

        modelBuilder.Entity<Features_List>(entity =>
        {
            entity.ToTable("Features_List");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.Country).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.First_Name).HasMaxLength(255);
            entity.Property(e => e.Last_Name).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone_Number).HasMaxLength(255);
            entity.Property(e => e.Postal_Code).HasMaxLength(255);
            entity.Property(e => e.State).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Hotel_Class).HasMaxLength(10);
            entity.Property(e => e.Hotel_Name).HasMaxLength(255);
            entity.Property(e => e.Location_Rating).HasMaxLength(50);
            entity.Property(e => e.Metro_Area).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(25);
            entity.Property(e => e.Postal_Code).HasMaxLength(25);
            entity.Property(e => e.Website).HasMaxLength(100);

            entity.HasOne(d => d.City).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.City_ID)
                .HasConstraintName("FK_Hotels_Cities");
        });

        modelBuilder.Entity<Hotel_Feature>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(255);

            entity.HasOne(d => d.Hotel).WithMany(p => p.Hotel_Features)
                .HasForeignKey(d => d.Hotel_ID)
                .HasConstraintName("FK_Hotel_Features_Hotels");
        });

        modelBuilder.Entity<Hotel_Image>(entity =>
        {
            entity.Property(e => e.Image_Id).HasMaxLength(100);

            entity.HasOne(d => d.Hotel).WithMany(p => p.Hotel_Images)
                .HasForeignKey(d => d.Hotel_ID)
                .HasConstraintName("FK_Hotel_Images_Hotels");
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.Property(e => e.Picture_Id).HasMaxLength(50);

            entity.HasOne(d => d.Hotel).WithMany(p => p.Pictures)
                .HasForeignKey(d => d.Hotel_ID)
                .HasConstraintName("FK_Pictures_Hotels");

            entity.HasOne(d => d.Room).WithMany(p => p.Pictures)
                .HasForeignKey(d => d.Room_ID)
                .HasConstraintName("FK_Pictures_Rooms");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.Property(e => e.Amount_Due).HasColumnType("money");
            entity.Property(e => e.Amount_Paid).HasColumnType("money");
            entity.Property(e => e.Check_In).HasColumnType("datetime");
            entity.Property(e => e.Check_Out).HasColumnType("datetime");

            entity.HasOne(d => d.Room).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.Room_ID)
                .HasConstraintName("FK_Reservations_Rooms");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.Property(e => e.Posted_On).HasColumnType("datetime");
            entity.Property(e => e.Reviewer_Name).HasMaxLength(255);

            entity.HasOne(d => d.Hotel).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.Hotel_ID)
                .HasConstraintName("FK_Reviews_Hotels");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.Property(e => e.Nighly_Rate).HasColumnType("money");
            entity.Property(e => e.Room_Image1).HasMaxLength(50);
            entity.Property(e => e.Room_Image2).HasMaxLength(50);
            entity.Property(e => e.Room_Image3).HasMaxLength(50);
            entity.Property(e => e.Room_Image4).HasMaxLength(50);
            entity.Property(e => e.Room_image5).HasMaxLength(50);

            entity.HasOne(d => d.Hotel).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.Hotel_ID)
                .HasConstraintName("FK_Rooms_Hotels");

            entity.HasOne(d => d.Room_TypeNavigation).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.Room_Type)
                .HasConstraintName("FK_Rooms_Room_Types");
        });

        modelBuilder.Entity<Room_Feature>(entity =>
        {
            entity.HasOne(d => d.Room).WithMany(p => p.Room_Features)
                .HasForeignKey(d => d.Room_ID)
                .HasConstraintName("FK_Room_Features_Rooms");
        });

        modelBuilder.Entity<Room_Type>(entity =>
        {
            entity.Property(e => e.Type_Name).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
