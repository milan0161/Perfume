﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230923123831_Initial Migration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Perfume", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Volume")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Perfumes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Goyette Group",
                            ImageUrl = "https://loremflickr.com/320/240?lock=1983928920",
                            Name = "Leland",
                            Scent = "Diesel",
                            Volume = 110f
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Cartwright Group",
                            ImageUrl = "https://loremflickr.com/320/240?lock=115213802",
                            Name = "Maynard",
                            Scent = "Electric",
                            Volume = 110f
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Bosco - Lindgren",
                            ImageUrl = "https://loremflickr.com/320/240?lock=612004936",
                            Name = "Annabell",
                            Scent = "Diesel",
                            Volume = 110f
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Wilkinson, Quigley and Bailey",
                            ImageUrl = "https://loremflickr.com/320/240?lock=928533423",
                            Name = "Jarrod",
                            Scent = "Gasoline",
                            Volume = 110f
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Stiedemann, Schmitt and Baumbach",
                            ImageUrl = "https://loremflickr.com/320/240?lock=1104687252",
                            Name = "Erling",
                            Scent = "Hybrid",
                            Volume = 110f
                        },
                        new
                        {
                            Id = 6,
                            Brand = "Gulgowski Inc",
                            ImageUrl = "https://loremflickr.com/320/240?lock=375193409",
                            Name = "Mylene",
                            Scent = "Hybrid",
                            Volume = 110f
                        },
                        new
                        {
                            Id = 7,
                            Brand = "Ankunding, Barton and Reilly",
                            ImageUrl = "https://loremflickr.com/320/240?lock=2076023217",
                            Name = "Amya",
                            Scent = "Diesel",
                            Volume = 110f
                        },
                        new
                        {
                            Id = 8,
                            Brand = "Reichel - Bashirian",
                            ImageUrl = "https://loremflickr.com/320/240?lock=1424085822",
                            Name = "Ansley",
                            Scent = "Diesel",
                            Volume = 110f
                        },
                        new
                        {
                            Id = 9,
                            Brand = "Kuhlman Inc",
                            ImageUrl = "https://loremflickr.com/320/240?lock=541003444",
                            Name = "Graham",
                            Scent = "Diesel",
                            Volume = 110f
                        },
                        new
                        {
                            Id = 10,
                            Brand = "Schiller, Wuckert and Hintz",
                            ImageUrl = "https://loremflickr.com/320/240?lock=851757316",
                            Name = "Dominic",
                            Scent = "Diesel",
                            Volume = 110f
                        },
                        new
                        {
                            Id = 11,
                            Brand = "Wunsch Inc",
                            ImageUrl = "https://loremflickr.com/320/240?lock=2117482831",
                            Name = "Abbie",
                            Scent = "Electric",
                            Volume = 110f
                        },
                        new
                        {
                            Id = 12,
                            Brand = "Bauch, Kilback and McCullough",
                            ImageUrl = "https://loremflickr.com/320/240?lock=710013855",
                            Name = "Robyn",
                            Scent = "Gasoline",
                            Volume = 110f
                        },
                        new
                        {
                            Id = 13,
                            Brand = "Wilderman - Denesik",
                            ImageUrl = "https://loremflickr.com/320/240?lock=1268119113",
                            Name = "Kelly",
                            Scent = "Diesel",
                            Volume = 110f
                        },
                        new
                        {
                            Id = 14,
                            Brand = "Hills, Effertz and O'Conner",
                            ImageUrl = "https://loremflickr.com/320/240?lock=1185053379",
                            Name = "Vernon",
                            Scent = "Electric",
                            Volume = 110f
                        },
                        new
                        {
                            Id = 15,
                            Brand = "Tremblay - Metz",
                            ImageUrl = "https://loremflickr.com/320/240?lock=1533243116",
                            Name = "Sophie",
                            Scent = "Hybrid",
                            Volume = 110f
                        },
                        new
                        {
                            Id = 16,
                            Brand = "Wyman - Swift",
                            ImageUrl = "https://loremflickr.com/320/240?lock=1924139421",
                            Name = "Clay",
                            Scent = "Gasoline",
                            Volume = 110f
                        },
                        new
                        {
                            Id = 17,
                            Brand = "Hodkiewicz - Lindgren",
                            ImageUrl = "https://loremflickr.com/320/240?lock=206837662",
                            Name = "Kris",
                            Scent = "Hybrid",
                            Volume = 110f
                        },
                        new
                        {
                            Id = 18,
                            Brand = "Simonis and Sons",
                            ImageUrl = "https://loremflickr.com/320/240?lock=2113060062",
                            Name = "Bridgette",
                            Scent = "Diesel",
                            Volume = 110f
                        },
                        new
                        {
                            Id = 19,
                            Brand = "Pacocha and Sons",
                            ImageUrl = "https://loremflickr.com/320/240?lock=857757327",
                            Name = "Alanis",
                            Scent = "Hybrid",
                            Volume = 110f
                        },
                        new
                        {
                            Id = 20,
                            Brand = "Wiza Group",
                            ImageUrl = "https://loremflickr.com/320/240?lock=1776116011",
                            Name = "Annabelle",
                            Scent = "Diesel",
                            Volume = 110f
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
