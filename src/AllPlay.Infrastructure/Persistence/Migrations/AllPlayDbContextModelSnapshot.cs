// <auto-generated />
using System;
using AllPlay.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AllPlay.Domain.Entities.Area", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Areas", "AllPlay");
                });

            modelBuilder.Entity("AllPlay.Domain.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

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

                    b.Navigation("Coordinates");
                });

            modelBuilder.Entity("AllPlay.Domain.Entities.Player", b =>
                {
                    b.HasOne("AllPlay.Domain.Entities.SportEvent", null)
                        .WithMany("Players")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AllPlay.Domain.Entities.SportEvent", b =>
                {
                    b.HasOne("AllPlay.Domain.Entities.Area", "Area")
                        .WithMany("SportEvents")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Area");
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
