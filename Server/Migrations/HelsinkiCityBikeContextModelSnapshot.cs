﻿// <auto-generated />
using System;
using HelsinkiCityBikeApp.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HelsinkiCityBikeApp.Server.Migrations
{
    [DbContext(typeof(HelsinkiCityBikeContext))]
    partial class HelsinkiCityBikeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("HelsinkiCityBikeApp.Shared.Station", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .HasColumnType("TEXT");

                    b.Property<int>("FID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Kapasiteet")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Kaupunki")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Namn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nimi")
                        .HasColumnType("TEXT");

                    b.Property<string>("Operaattor")
                        .HasColumnType("TEXT");

                    b.Property<string>("Osoite")
                        .HasColumnType("TEXT");

                    b.Property<string>("Stad")
                        .HasColumnType("TEXT");

                    b.Property<double>("X")
                        .HasColumnType("REAL");

                    b.Property<double>("Y")
                        .HasColumnType("REAL");

                    b.HasKey("ID");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("HelsinkiCityBikeApp.Shared.Trips", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CoveredDistance")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Departure")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DepartureStationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DepartureStationName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Return")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ReturnStationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReturnStationName")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Trips");
                });
#pragma warning restore 612, 618
        }
    }
}