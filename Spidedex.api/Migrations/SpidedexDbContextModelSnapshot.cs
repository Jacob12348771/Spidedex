﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Spidedex.api.Migrations
{
    [DbContext(typeof(SpidedexDbContext))]
    partial class SpidedexDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Spider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("DateObtained")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Diet")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Temperament")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserInfo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Spiders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateObtained = new DateOnly(2021, 10, 1),
                            Description = "A cool spooder",
                            Diet = "Crickets",
                            Name = "Charlotte",
                            Size = "3 inches",
                            Species = "Argiope aurantia",
                            Temperament = 4,
                            UserInfo = "test123@gmail.com"
                        },
                        new
                        {
                            Id = 2,
                            DateObtained = new DateOnly(2023, 9, 13),
                            Description = "My spooder",
                            Diet = "Locusts",
                            Name = "Luna",
                            Size = "4 inches",
                            Species = "Tliltocatl vagans",
                            Temperament = 0,
                            UserInfo = "test123@gmail.com"
                        },
                        new
                        {
                            Id = 3,
                            DateObtained = new DateOnly(2022, 5, 23),
                            Description = "Ouch it hurts",
                            Diet = "Crickets",
                            Name = "Pokey",
                            Size = "5 inches",
                            Species = "Poecilotheria regalis",
                            Temperament = 2,
                            UserInfo = "test123@gmail.com"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}