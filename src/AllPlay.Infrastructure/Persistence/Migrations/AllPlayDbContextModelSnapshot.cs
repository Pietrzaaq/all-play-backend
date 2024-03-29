﻿// <auto-generated />
using System;
using AllPlay.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

#nullable disable

namespace AllPlay.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AllPlayDbContext))]
    partial class AllPlayDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("AllPlay")
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AllPlay.Domain.Entities.Area", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Access")
                        .HasColumnType("bit");

                    b.Property<string>("Barrier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryIso")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CountryRegion")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("FormattedAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("HasMultipleSports")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsOutdoorArea")
                        .HasColumnType("bit");

                    b.Property<string>("Leisure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Lit")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("OpenStreetMapId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpenStreetMapName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Point>("Point")
                        .IsRequired()
                        .HasColumnType("geography");

                    b.Property<Polygon>("Polygon")
                        .IsRequired()
                        .HasColumnType("geography");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Sport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Surface")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Areas", "AllPlay");
                });

            modelBuilder.Entity("AllPlay.Domain.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SportEventId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("SportEventId");

                    b.ToTable("Players", "AllPlay");
                });

            modelBuilder.Entity("AllPlay.Domain.Entities.SportEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AreaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EventEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EventStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SportType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("SportEvents", "AllPlay");
                });

            modelBuilder.Entity("AllPlay.Domain.Entities.Area", b =>
                {
                    b.OwnsOne("AllPlay.Domain.ValueObjects.Coordinates", "Coordinates", b1 =>
                        {
                            b1.Property<Guid>("AreaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float")
                                .HasColumnName("Latitude");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float")
                                .HasColumnName("Longitude");

                            b1.HasKey("AreaId");

                            b1.ToTable("Areas", "AllPlay");

                            b1.WithOwner()
                                .HasForeignKey("AreaId");
                        });

                    b.Navigation("Coordinates")
                        .IsRequired();
                });

            modelBuilder.Entity("AllPlay.Domain.Entities.Player", b =>
                {
                    b.HasOne("AllPlay.Domain.Entities.SportEvent", null)
                        .WithMany("Players")
                        .HasForeignKey("SportEventId");
                });

            modelBuilder.Entity("AllPlay.Domain.Entities.SportEvent", b =>
                {
                    b.HasOne("AllPlay.Domain.Entities.Area", null)
                        .WithMany("SportEvents")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AllPlay.Domain.Entities.Area", b =>
                {
                    b.Navigation("SportEvents");
                });

            modelBuilder.Entity("AllPlay.Domain.Entities.SportEvent", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
