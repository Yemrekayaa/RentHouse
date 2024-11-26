﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentHouse.Persistence.Context;

#nullable disable

namespace RentHouse.Persistence.Migrations
{
    [DbContext(typeof(RentHouseContext))]
    [Migration("20241126005257_update_lat_lon_type")]
    partial class update_lat_lon_type
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RentHouse.Domain.Entities.About", b =>
                {
                    b.Property<int>("AboutID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AboutID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AboutID");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("RentHouse.Domain.Entities.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("RentHouse.Domain.Entities.Banner", b =>
                {
                    b.Property<int>("BannerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BannerID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BannerID");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("RentHouse.Domain.Entities.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactID"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("RentHouse.Domain.Entities.Feature", b =>
                {
                    b.Property<int>("FeatureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeatureID"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FeatureID");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("RentHouse.Domain.Entities.FooterAddress", b =>
                {
                    b.Property<int>("FooterAddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FooterAddressID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FooterAddressID");

                    b.ToTable("FooterAddresses");
                });

            modelBuilder.Entity("RentHouse.Domain.Entities.House", b =>
                {
                    b.Property<int>("HouseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HouseID"));

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<string>("BigImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(18,8)");

                    b.Property<int>("LocationID")
                        .HasColumnType("int");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(18,8)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("NumberOfBeds")
                        .HasColumnType("tinyint");

                    b.Property<byte>("NumberOfRooms")
                        .HasColumnType("tinyint");

                    b.Property<decimal>("WeekdayPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WeekendPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("HouseID");

                    b.HasIndex("LocationID");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("RentHouse.Domain.Entities.HouseFeature", b =>
                {
                    b.Property<int>("HouseFeatureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HouseFeatureId"));

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.HasKey("HouseFeatureId");

                    b.HasIndex("FeatureId");

                    b.HasIndex("HouseId");

                    b.ToTable("HouseFeatures");
                });

            modelBuilder.Entity("RentHouse.Domain.Entities.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationID"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("RentHouse.Domain.Entities.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationID"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HouseID")
                        .HasColumnType("int");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ReservationID");

                    b.HasIndex("HouseID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RentHouse.Domain.Entities.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IconUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("RentHouse.Domain.Entities.Setting", b =>
                {
                    b.Property<int>("SettingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SettingID"));

                    b.Property<int>("BannerID")
                        .HasColumnType("int");

                    b.HasKey("SettingID");

                    b.HasIndex("BannerID");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("RentHouse.Domain.Entities.SocialMedia", b =>
                {
                    b.Property<int>("SocialMediaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SocialMediaID"));

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SocialMediaID");

                    b.ToTable("SocialMedias");
                });

            modelBuilder.Entity("RentHouse.Domain.Entities.Testimonial", b =>
                {
                    b.Property<int>("TestimonialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestimonialID"));

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TestimonialID");

                    b.ToTable("Testimonials");
                });

            modelBuilder.Entity("RentHouse.Domain.Entities.House", b =>
                {
                    b.HasOne("RentHouse.Domain.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("RentHouse.Domain.Entities.HouseFeature", b =>
                {
                    b.HasOne("RentHouse.Domain.Entities.Feature", "Feature")
                        .WithMany("HouseFeatures")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentHouse.Domain.Entities.House", "House")
                        .WithMany("HouseFeatures")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feature");

                    b.Navigation("House");
                });

            modelBuilder.Entity("RentHouse.Domain.Entities.Reservation", b =>
                {
                    b.HasOne("RentHouse.Domain.Entities.House", "House")
                        .WithMany("Reservations")
                        .HasForeignKey("HouseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("RentHouse.Domain.Entities.Setting", b =>
                {
                    b.HasOne("RentHouse.Domain.Entities.Banner", "Banner")
                        .WithMany()
                        .HasForeignKey("BannerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Banner");
                });

            modelBuilder.Entity("RentHouse.Domain.Entities.Feature", b =>
                {
                    b.Navigation("HouseFeatures");
                });

            modelBuilder.Entity("RentHouse.Domain.Entities.House", b =>
                {
                    b.Navigation("HouseFeatures");

                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
