﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RevHousingAPI;

namespace RevHousingAPI.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20190808151308_azdb")]
    partial class azdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RHEntities.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<int>("ProviderID");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("TrainingCenter")
                        .IsRequired();

                    b.Property<string>("ZipCode")
                        .IsRequired();

                    b.HasKey("LocationID");

                    b.HasIndex("ProviderID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("RHEntities.Provider", b =>
                {
                    b.Property<int>("ProviderID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.HasKey("ProviderID");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("RHEntities.Room", b =>
                {
                    b.Property<int>("RoomID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentOccupancy");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<bool>("IsActive");

                    b.Property<int>("LocationID");

                    b.Property<int>("MaxOccupancy");

                    b.Property<string>("RoomNumber")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("RoomID");

                    b.HasIndex("LocationID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("RHEntities.Location", b =>
                {
                    b.HasOne("RHEntities.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RHEntities.Room", b =>
                {
                    b.HasOne("RHEntities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
