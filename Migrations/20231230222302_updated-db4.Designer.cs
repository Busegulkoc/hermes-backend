﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hermesTour.Data;

#nullable disable

namespace hermesTour.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231230222302_updated-db4")]
    partial class updateddb4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CityCountryTour", b =>
                {
                    b.Property<int>("CityCountryListcityCountryId")
                        .HasColumnType("int");

                    b.Property<int>("TourstourId")
                        .HasColumnType("int");

                    b.HasKey("CityCountryListcityCountryId", "TourstourId");

                    b.HasIndex("TourstourId");

                    b.ToTable("CityCountryTour");
                });

            modelBuilder.Entity("HotelTour", b =>
                {
                    b.Property<int>("HotelListhotelId")
                        .HasColumnType("int");

                    b.Property<int>("TourstourId")
                        .HasColumnType("int");

                    b.HasKey("HotelListhotelId", "TourstourId");

                    b.HasIndex("TourstourId");

                    b.ToTable("HotelTour");
                });

            modelBuilder.Entity("TourTransportationVehicle", b =>
                {
                    b.Property<int>("TourstourId")
                        .HasColumnType("int");

                    b.Property<int>("TransportationVehicleListtransportationVehicleId")
                        .HasColumnType("int");

                    b.HasKey("TourstourId", "TransportationVehicleListtransportationVehicleId");

                    b.HasIndex("TransportationVehicleListtransportationVehicleId");

                    b.ToTable("TourTransportationVehicle");
                });

            modelBuilder.Entity("Tourtraveler", b =>
                {
                    b.Property<int>("TourstourId")
                        .HasColumnType("int");

                    b.Property<int>("TravelerListtravelerId")
                        .HasColumnType("int");

                    b.HasKey("TourstourId", "TravelerListtravelerId");

                    b.HasIndex("TravelerListtravelerId");

                    b.ToTable("Tourtraveler");
                });

            modelBuilder.Entity("hermesTour.Models.Admin", b =>
                {
                    b.Property<int>("adminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("adminId"));

                    b.Property<string>("eMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("salary")
                        .HasColumnType("int");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("adminId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("hermesTour.Models.CityCountry", b =>
                {
                    b.Property<int>("cityCountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cityCountryId"));

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cityCountryId");

                    b.ToTable("CityCountry");
                });

            modelBuilder.Entity("hermesTour.Models.Comment", b =>
                {
                    b.Property<int>("commentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("commentId"));

                    b.Property<string>("commentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tourId")
                        .HasColumnType("int");

                    b.Property<int>("travelerId")
                        .HasColumnType("int");

                    b.HasKey("commentId");

                    b.HasIndex("tourId");

                    b.HasIndex("travelerId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("hermesTour.Models.Hotel", b =>
                {
                    b.Property<int>("hotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("hotelId"));

                    b.Property<int>("cityCountryId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("hotelId");

                    b.HasIndex("cityCountryId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("hermesTour.Models.Manager", b =>
                {
                    b.Property<int>("managerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("managerId"));

                    b.Property<int>("cityCountryId")
                        .HasColumnType("int");

                    b.Property<string>("eMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("salary")
                        .HasColumnType("int");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("managerId");

                    b.HasIndex("cityCountryId")
                        .IsUnique();

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("hermesTour.Models.Tour", b =>
                {
                    b.Property<int>("tourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tourId"));

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("rating")
                        .HasColumnType("int");

                    b.HasKey("tourId");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("hermesTour.Models.TransportationVehicle", b =>
                {
                    b.Property<int>("transportationVehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("transportationVehicleId"));

                    b.Property<int>("capacity")
                        .HasColumnType("int");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("transportationVehicleId");

                    b.ToTable("TransportationVehicle");
                });

            modelBuilder.Entity("hermesTour.Models.TransportationWorkers", b =>
                {
                    b.Property<int>("transportationWorkersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("transportationWorkersId"));

                    b.Property<string>("eMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("experience")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("salary")
                        .HasColumnType("int");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("transportationVehicleId")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("transportationWorkersId");

                    b.HasIndex("transportationVehicleId");

                    b.ToTable("TransportationWorkers");
                });

            modelBuilder.Entity("hermesTour.Models.traveler", b =>
                {
                    b.Property<int>("travelerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("travelerId"));

                    b.Property<string>("eMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("vip")
                        .HasColumnType("bit");

                    b.Property<bool>("visa")
                        .HasColumnType("bit");

                    b.Property<int>("wallet")
                        .HasColumnType("int");

                    b.HasKey("travelerId");

                    b.ToTable("Travelers");
                });

            modelBuilder.Entity("CityCountryTour", b =>
                {
                    b.HasOne("hermesTour.Models.CityCountry", null)
                        .WithMany()
                        .HasForeignKey("CityCountryListcityCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hermesTour.Models.Tour", null)
                        .WithMany()
                        .HasForeignKey("TourstourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelTour", b =>
                {
                    b.HasOne("hermesTour.Models.Hotel", null)
                        .WithMany()
                        .HasForeignKey("HotelListhotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hermesTour.Models.Tour", null)
                        .WithMany()
                        .HasForeignKey("TourstourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TourTransportationVehicle", b =>
                {
                    b.HasOne("hermesTour.Models.Tour", null)
                        .WithMany()
                        .HasForeignKey("TourstourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hermesTour.Models.TransportationVehicle", null)
                        .WithMany()
                        .HasForeignKey("TransportationVehicleListtransportationVehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tourtraveler", b =>
                {
                    b.HasOne("hermesTour.Models.Tour", null)
                        .WithMany()
                        .HasForeignKey("TourstourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hermesTour.Models.traveler", null)
                        .WithMany()
                        .HasForeignKey("TravelerListtravelerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("hermesTour.Models.Comment", b =>
                {
                    b.HasOne("hermesTour.Models.Tour", "tour")
                        .WithMany("CommentList")
                        .HasForeignKey("tourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("hermesTour.Models.traveler", "traveler")
                        .WithMany("Comments")
                        .HasForeignKey("travelerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tour");

                    b.Navigation("traveler");
                });

            modelBuilder.Entity("hermesTour.Models.Hotel", b =>
                {
                    b.HasOne("hermesTour.Models.CityCountry", "cityCountry")
                        .WithMany("HotelList")
                        .HasForeignKey("cityCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cityCountry");
                });

            modelBuilder.Entity("hermesTour.Models.Manager", b =>
                {
                    b.HasOne("hermesTour.Models.CityCountry", "cityCountry")
                        .WithOne("manager")
                        .HasForeignKey("hermesTour.Models.Manager", "cityCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cityCountry");
                });

            modelBuilder.Entity("hermesTour.Models.TransportationWorkers", b =>
                {
                    b.HasOne("hermesTour.Models.TransportationVehicle", "transportationVehicle")
                        .WithMany("TransportationWorkers")
                        .HasForeignKey("transportationVehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("transportationVehicle");
                });

            modelBuilder.Entity("hermesTour.Models.CityCountry", b =>
                {
                    b.Navigation("HotelList");

                    b.Navigation("manager")
                        .IsRequired();
                });

            modelBuilder.Entity("hermesTour.Models.Tour", b =>
                {
                    b.Navigation("CommentList");
                });

            modelBuilder.Entity("hermesTour.Models.TransportationVehicle", b =>
                {
                    b.Navigation("TransportationWorkers");
                });

            modelBuilder.Entity("hermesTour.Models.traveler", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
