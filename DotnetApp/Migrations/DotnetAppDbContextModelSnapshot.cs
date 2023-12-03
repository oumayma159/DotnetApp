﻿// <auto-generated />
using System;
using DotnetApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DotnetApp.Migrations
{
    [DbContext(typeof(DotnetAppDbContext))]
    partial class DotnetAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerMovie", b =>
                {
                    b.Property<Guid>("MoviesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("customersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MoviesId", "customersId");

                    b.HasIndex("customersId");

                    b.ToTable("CustomerMovie");
                });

            modelBuilder.Entity("DotnetApp.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MembershiptypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MembershiptypeId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DotnetApp.Models.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = new Guid("84ca0bcd-082c-49cb-aa77-ea2f1f5f8285"),
                            GenreName = "GenreFromJsonFile1"
                        },
                        new
                        {
                            Id = new Guid("79e6f638-d7e7-4f63-8365-f172cb925381"),
                            GenreName = "GenreFromJsonFile2"
                        });
                });

            modelBuilder.Entity("DotnetApp.Models.Membershiptype", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("DiscountRate")
                        .HasColumnType("float");

                    b.Property<int>("DurationInMonths")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SignUpFee")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Membershiptypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("84ca0bcd-082c-49cb-aa77-ea2f1f5f8281"),
                            DiscountRate = 0.050000000000000003,
                            DurationInMonths = 0,
                            Name = "offre normale",
                            SignUpFee = 0.0
                        },
                        new
                        {
                            Id = new Guid("84ca0bcd-082c-49cb-aa77-ea2f1f5f9285"),
                            DiscountRate = 0.10000000000000001,
                            DurationInMonths = 0,
                            Name = "offre moyenne",
                            SignUpFee = 0.0
                        },
                        new
                        {
                            Id = new Guid("84ca0bcd-082c-49cb-aa77-ea2f1f5f8685"),
                            DiscountRate = 0.20000000000000001,
                            DurationInMonths = 0,
                            Name = "offre premium",
                            SignUpFee = 0.0
                        });
                });

            modelBuilder.Entity("DotnetApp.Models.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poster")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Released")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("CustomerMovie", b =>
                {
                    b.HasOne("DotnetApp.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotnetApp.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("customersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DotnetApp.Models.Customer", b =>
                {
                    b.HasOne("DotnetApp.Models.Membershiptype", "Membershiptype")
                        .WithMany("Customers")
                        .HasForeignKey("MembershiptypeId");

                    b.Navigation("Membershiptype");
                });

            modelBuilder.Entity("DotnetApp.Models.Movie", b =>
                {
                    b.HasOne("DotnetApp.Models.Genre", "genre")
                        .WithMany("movies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("genre");
                });

            modelBuilder.Entity("DotnetApp.Models.Genre", b =>
                {
                    b.Navigation("movies");
                });

            modelBuilder.Entity("DotnetApp.Models.Membershiptype", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}